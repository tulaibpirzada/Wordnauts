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
    public void GetPlayerDailyLevelDataFromSnapshot()
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
    public void GetPlayerMultiClueDataFromSnapshot()
    {
        multiClue = new multiClueDic();
        multiClue.LevelNo = Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.userDataSnapshot, "multiLevel/LevelNo"));
       
    }
    public void GetPlayerSingleClueDataFromSnapshot()
    {
        singleClue = new singleClueDic();
        singleClue.LevelNo= Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.userDataSnapshot, "singleClue/LevelNo"));
        singleClue.PackNo = Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.userDataSnapshot, "singleClue/PackNo"));

    }
    public void GetPlayerDataFromSnapshot()
    {
        stars = Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.userDataSnapshot, "stars"));
        hints = Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.userDataSnapshot, "hints"));
    }
    public void UpdateCompletionPercentage()
    {
        completionPercent = ((singleClue.LevelNo) * (singleClue.PackNo)) +(multiClue.LevelNo)/(MultipleMultiPackModel.Instance.TotalLevels+(MultiplePackModel.Instance.TotalPacks* MultiplePackModel.Instance.packsList[0].TotalLevels));
    }
    public void UpdateStarsAndHints(int PrestigePoints,int Hints)
    {
        stars = stars + PrestigePoints;
        hints = hints + Hints;
    }

    public bool IsDailyLevelAvailableToday()
    {
        string today=DateTime.Now.ToString("dd.MM.yyy");
        if (today==dailyLevel.date)
        {
            return dailyLevel.isAvailable;
        }
        else
        {
            dailyLevel.date = today;
            dailyLevel.isAvailable = true;
            return true;
        }
    }
}
