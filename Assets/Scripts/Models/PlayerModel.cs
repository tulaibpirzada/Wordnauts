using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[Serializable]
public class PlayerModel: Singleton <PlayerModel>
{
    public int completionPercent;
    public int stars;
    public int hints;
    public int moneySpent;
    public int appRating;
    public dailyLevelDic dailyLevel;
    public singleClueDic singleClue;
    public multiClueDic multiClue;
    
    public bool IsDailyLevelAvailable
	{
		get;
		set;
	}


	public void SetUpPlayerData()
	{
		this.IsDailyLevelAvailable = true;
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

}
