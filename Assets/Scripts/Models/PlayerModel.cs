using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerModel: Singleton <PlayerModel>
{
   // public string deviceID;
    public int completionPercent;
    public int stars;
    public int hints;
    public Dictionary<string, string> dailyLevel=new Dictionary<string, string>();
  /*  dailyLevel = new Dictionary<string, string>();
        dailyLevel.Add("isAvailable","true");
        dailyLevel.Add("date",DateTime.Today.ToString());
        dailyLevel.Add("LevelNo", */
    public Dictionary<string, int> singleClue = new Dictionary<string, int>();
    public Dictionary<string, int> multiClue = new Dictionary<string, int>();
    public string dl;
    public string sc;
    public string mc;
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
       // deviceID= SystemInfo.deviceUniqueIdentifier;
        completionPercent = 0;
        stars = 0;
        hints = 0;
        moneySpent = 0;
        appRating = 0;

        // setting up daily level data
      //  dailyLevel = new Dictionary<string, string>();
        dailyLevel.Add("isAvailable","true");
        dailyLevel.Add("date",DateTime.Today.ToString());
        dailyLevel.Add("LevelNo", "0");
       // dl = JsonUtility.ToJson(dailyLevel);

     //   singleClue = new Dictionary<string, int>();
        singleClue.Add("LevelNo",0);
        singleClue.Add("SubLevelNo", 0);

       // multiClue = new Dictionary<string, int>();
        multiClue.Add("LevelNo",0);

        dl = JsonUtility.ToJson(dailyLevel);
        sc = JsonUtility.ToJson(singleClue);
        mc = JsonUtility.ToJson(multiClue);

    }

}
