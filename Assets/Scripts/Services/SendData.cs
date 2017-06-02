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
    public void uploadPlayerData()
    {
        //Initilize all the user fields and convert to JSON
        string json = JsonUtility.ToJson(PlayerModel.Instance);
        Debug.Log(json);
        Debug.Log(PlayerModel.Instance.GetDeviceId());


        //Create a user entry
       FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DatabaseModel.Instance.dbPath);
        FirebaseDatabase.DefaultInstance
       .GetReference("users/").Child(PlayerModel.Instance.GetDeviceId()).SetRawJsonValueAsync(json).ContinueWith(task =>
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

    public void UpdatePlayerDailyLevelData()
    {
        string json = JsonUtility.ToJson(PlayerModel.Instance.dailyLevel);
        Debug.Log(json);

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DatabaseModel.Instance.dbPath);
        FirebaseDatabase.DefaultInstance
       .GetReference("users/").Child(PlayerModel.Instance.GetDeviceId()).Child("dailyLevel").SetRawJsonValueAsync(json).ContinueWith(task =>
       {
           if (task.IsFaulted)
           {
               Debug.Log("Error updating user");

           }
           else if (task.IsCompleted)
           {
               Debug.Log("User Updated Successfully");


           }
       });
    }
    public void UpdatePlayerData()
    {

        string json = JsonUtility.ToJson(PlayerModel.Instance);
        Debug.Log(json);

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DatabaseModel.Instance.dbPath);
        FirebaseDatabase.DefaultInstance
       .GetReference("users/").Child(PlayerModel.Instance.GetDeviceId()).SetRawJsonValueAsync(json).ContinueWith(task =>
       {
           if (task.IsFaulted)
           {
               Debug.Log("Error updating user");

           }
           else if (task.IsCompleted)
           {
               Debug.Log("User Updated Successfully");


           }
       });
    }
}


