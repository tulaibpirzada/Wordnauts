using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel: Singleton <PlayerModel>
{
    public string deviceID;
    public float completionPercent;
    public int stars;
    public int hints;
    public Dictionary<string, string> dailyLvlData;
    public Dictionary<string, string> singleClueLvlData;
    public Dictionary<string, string> multiClueLvlData;
    public int moneySpent;
    public int appRating;

    public bool IsDailyLevelAvailable
	{
		get;
		set;
	}

	public void SetUpPlayerData()
	{
		this.IsDailyLevelAvailable = true;
        
	}

}
