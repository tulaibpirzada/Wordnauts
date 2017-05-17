using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

    
public class  RetrieveData : Singleton<RetrieveData>
{
	public Database dbObject;
	public delegate void OnApiCallResponse();

	private OnApiCallResponse callBackFunction; 

	RetrieveData ()
	{
		Debug.Log ("Running Constructor");
		dbObject = new Database ();
		Debug.Log (dbObject.dbPath);
       
	}

	public void GetDailyLevels (OnApiCallResponse callBack)
	{
		Debug.Log (dbObject.dbPath);
		callBackFunction = callBack;
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl (dbObject.dbPath);
		FirebaseDatabase.DefaultInstance
       .GetReference (dbObject.dailyPackName)
       .GetValueAsync ().ContinueWith (task => {
			if (task.IsFaulted) {
				// Handle the error...
			} else if (task.IsCompleted) {
				DataSnapshot snapshot = task.Result;
				Debug.Log (snapshot);
				callBackFunction();
			}
		});
	}
}
    
