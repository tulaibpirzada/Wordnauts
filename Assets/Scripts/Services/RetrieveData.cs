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
    public DataSnapshot snapshot;

	private OnApiCallResponse callBackFunction; 

    public void LoadGameData(OnApiCallResponse callBack)
    {
        
        callBackFunction = callBack;
        
        GetUsersData();
        


    }
	public void GetDailyLevels ()
	{
      FetchSnapshot(DatabaseModel.Instance.dailyPackName, 0,true);
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
               // Debug.Log("key"+snapshot.Key);
               if (snapshot.Value != null)
               {
                   DatabaseModel.Instance.userExists = true;
               }
               DatabaseModel.Instance.userDataSnapshot = snapshot;
                GetSingleClueLevels();
                GetMultiClueLevels();
                GetDailyLevels();
           }
       });

    }
   
    public void GetSingleClueLevels()
    {
       
        FetchSnapshot(DatabaseModel.Instance.singleClueName, 1,false);
    }

    public void GetMultiClueLevels()
    {
        FetchSnapshot(DatabaseModel.Instance.multiClueName, 2, false);
    }
    private void FetchSnapshot(string path,int puzzleType, bool IsCallback)
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DatabaseModel.Instance.dbPath);
        FirebaseDatabase.DefaultInstance
       .GetReference(path)
       .GetValueAsync().ContinueWith(task => {
           if (task.IsFaulted)
           {
               // Handle the error...
           }
           else if (task.IsCompleted)
           {
               snapshot=task.Result;
               if (puzzleType==0)
               {
                   DatabaseModel.Instance.dailyLevelSnapshot = snapshot;
               }
               else if (puzzleType == 1)
               {
                   DatabaseModel.Instance.singleClueSnapshot = snapshot;
               }
               else
               {
                   DatabaseModel.Instance.multiClueSnapshot = snapshot;
               }
              // ds = snapshot;
              // DatabaseModel.Instance.ds = snapshot;
               if (IsCallback)
               {
                   callBackFunction();
               }

           }
       });
    }
}
    
