using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

    
public class  RetrieveData : Singleton<RetrieveData>
{
	//public DatabaseModel dbObject;
	public delegate void OnApiCallResponse();

	private OnApiCallResponse callBackFunction; 

	RetrieveData ()
	{
	//	Debug.Log ("Running Constructor");
	//	dbObject = new DatabaseModel ();
	//	Debug.Log (dbObject.dbPath);
       
	}

	public void GetDailyLevels (OnApiCallResponse callBack)
	{
		Debug.Log (DatabaseModel.Instance.dbPath);
		callBackFunction = callBack;
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl (DatabaseModel.Instance.dbPath);
		FirebaseDatabase.DefaultInstance
       .GetReference (DatabaseModel.Instance.dailyPackName)
       .GetValueAsync ().ContinueWith (task => {
			if (task.IsFaulted) {
				// Handle the error...
			} else if (task.IsCompleted) {
				DataSnapshot snapshot = task.Result;
               DatabaseModel.Instance.DS = snapshot;
				Debug.Log (snapshot);
				callBackFunction();
			}
		});
	}
}
    
