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

    public void LoadGameData(OnApiCallResponse callBack,string deviceID)
    {
        callBackFunction = callBack;
        GetUsersData(deviceID);


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
				Debug.Log (snapshot);
				callBackFunction();
			}
		});
	}
    public void GetUsersData(string deviceid)
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DatabaseModel.Instance.dbPath);
        FirebaseDatabase.DefaultInstance
       .GetReference("users/"+deviceid)
       .GetValueAsync().ContinueWith(task => {
           if (task.IsFaulted) {
               //Handle this error...
           } else if (task.IsCompleted) {
               DataSnapshot snapshot = task.Result;
               if (snapshot!=null)
               {
                   DatabaseModel.Instance.userExists = true;
               }
               DatabaseModel.Instance.userDataSnapshot = snapshot;
               Debug.Log(snapshot);
                GetDailyLevels();
           }
       });

    }
}
    
