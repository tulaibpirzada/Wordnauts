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
               if (snapshot.Value != null)
               {
                   DatabaseModel.Instance.userExists = true;
               }
               DatabaseModel.Instance.userDataSnapshot = snapshot;
                FetchSnapshotofGame();
           }
       });

    }
   
    private void FetchSnapshotofGame()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DatabaseModel.Instance.dbPath);
        FirebaseDatabase.DefaultInstance
       .GetReference("game/")
       .GetValueAsync().ContinueWith(task => {
           if (task.IsFaulted)
           {
               // Handle the error...
           }
           else if (task.IsCompleted)
           {


               snapshot = task.Result;
               DatabaseModel.Instance.dailyLevelSnapshot = ServerController.Instance.GetDatasnapshot(snapshot, DatabaseModel.Instance.dailyPackName);
               DatabaseModel.Instance.singleClueSnapshot = ServerController.Instance.GetDatasnapshot(snapshot, DatabaseModel.Instance.singleClueName);
               DatabaseModel.Instance.multiClueSnapshot = ServerController.Instance.GetDatasnapshot(snapshot, DatabaseModel.Instance.multiClueName);
               callBackFunction();             
           }
       });
    }
}
    
