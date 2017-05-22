﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using System.Threading;

public class  RetrieveData : Singleton<RetrieveData>
{
	//public DatabaseModel dbObject;
	public delegate void OnApiCallResponse();

	private OnApiCallResponse callBackFunction; 

    public void LoadGameData(OnApiCallResponse callBack)
    {
        
        callBackFunction = callBack;
        GetUsersData();


    }
	public void GetDailyLevels ()
	{
		Debug.Log (DatabaseModel.Instance.dbPath);
		
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl (DatabaseModel.Instance.dbPath);
		FirebaseDatabase.DefaultInstance
       .GetReference (DatabaseModel.Instance.dailyPackName)
       .GetValueAsync ().ContinueWith (task => {
			if (task.IsFaulted) {
				// Handle the error...
			} else if (task.IsCompleted) {
				DataSnapshot snapshot = task.Result;
                DatabaseModel.Instance.dailyLevelSnapshot = snapshot;
				callBackFunction();
			}
		});
	}
    public void GetUsersData()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DatabaseModel.Instance.dbPath);
        DatabaseReference dBRef = FirebaseDatabase.DefaultInstance
       .GetReference("users/" + PlayerModel.Instance.GetDeviceId());

        dBRef.GetValueAsync().ContinueWith(task => {
           if (task.IsFaulted) {
               //Handle this error...
           } else if (task.IsCompleted) {
               DataSnapshot snapshot = task.Result;
                Debug.Log("key"+snapshot.Key);
               // Debug.Log(if(snapshot.Value));
               if (snapshot.Value != null)
               {
                   DatabaseModel.Instance.userExists = true;
               }
               DatabaseModel.Instance.userDataSnapshot = snapshot;
               //Debug.Log(snapshot);
               GetDailyLevels();
           }
       });

    }

}
    
