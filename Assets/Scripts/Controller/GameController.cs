using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> {

	//Loads the game
	public void RetrieveDataFromServer()
	{
		ScreenTransitionManager.Instance.ShowScreen (GameConstants.Screens.SPLASH_SCREEN);
		RetrieveData.Instance.GetDailyLevels(LoadGame);
		

	}

	public void LoadGame() {
        PlayerModel.Instance.SetUpPlayerData();
        MainMenuController.Instance.ShowMainMenuScreen ();
        ServerController.Instance.PopulateDailyLevelData();
        Debug.Log(DailyLevelModel.Instance.solution);

    }
}
