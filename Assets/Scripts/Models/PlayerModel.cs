using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel: Singleton <PlayerModel>
{
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
