using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Firebase.Unity.Editor;
using Firebase.Database;
using Firebase;


class SendData : Singleton<SendData>
{
    public void uploadPlayerData(string deviceID)
    {
        //Initilize all the user fields and convert to JSON
        string json = JsonUtility.ToJson(PlayerModel.Instance);
        Debug.Log(json);


        //Create a user entry
       FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DatabaseModel.Instance.dbPath);
        FirebaseDatabase.DefaultInstance
       .GetReference("users/").Child(deviceID).SetRawJsonValueAsync(json).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("Get:UserData:CreateUser:Error creating user");

            }
            else if (task.IsCompleted)
            {
                Debug.Log("Get:UserData:CreateUser:User Created Successfully");


            }
        });
    }
}


