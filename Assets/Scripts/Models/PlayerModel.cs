using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[Serializable]
public class PlayerModel: Singleton <PlayerModel>
{
    private string deviceID;
    public int completionPercent;
    public int stars;
    public int hints;
    public int moneySpent;
    public int appRating;
    public dailyLevelDic dailyLevel;
    public singleClueDic singleClue;
    public multiClueDic multiClue;
    
    /*public bool IsDailyLevelAvailable
	{
		get;
		set;
	}*/
    public void SetDeviceID()
    {
        deviceID = SystemInfo.deviceUniqueIdentifier;
    }
    public string GetDeviceId()
    {
        
        return deviceID;
    }

	public void SetUpPlayerData()
	{
	//	this.IsDailyLevelAvailable = true;
       // deviceID= SystemInfo.deviceUniqueIdentifier;
        completionPercent = 0;
        stars = 0;
        hints = 0;
        moneySpent = 0;
        appRating = 0;
        dailyLevel = new dailyLevelDic();
        singleClue = new singleClueDic();
        multiClue = new multiClueDic();




}
    public void SetPlayerDailyLevelDataFromSnapshot()
    {
        dailyLevel = new dailyLevelDic();
        dailyLevel.LevelNo = Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.userDataSnapshot, "dailyLevel/LevelNo"));
        dailyLevel.isAvailable = Convert.ToBoolean(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.userDataSnapshot, "dailyLevel/isAvailable"));
        dailyLevel.date = Convert.ToString(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.userDataSnapshot, "dailyLevel/date"));

        if (!dailyLevel.isAvailable && dailyLevel.date!= DateTime.Now.ToString("dd.MM.yyy"))
        {
            dailyLevel.isAvailable = true;
            dailyLevel.date = DateTime.Now.ToString("dd.MM.yyy");
            SendData.Instance.UpdatePlayerDailyLevelData();
        }
    }
    public void SetPlayerDataFromSnapshot()
    {
        stars = Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.userDataSnapshot, "stars"));
        hints = Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.userDataSnapshot, "hints"));
    }
}
