using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> {

	//Loads the game
	public void RetrieveDataFromServer()
	{
		ScreenTransitionManager.Instance.ShowScreen (GameConstants.Screens.SPLASH_SCREEN);
		RetrieveData.Instance.LoadGameData(LoadGame, SystemInfo.deviceUniqueIdentifier);
        

    }

	public void LoadGame()
    {
        if (!DatabaseModel.Instance.userExists)
        {
            PlayerModel.Instance.SetUpPlayerData();
            SendData.Instance.uploadPlayerData(SystemInfo.deviceUniqueIdentifier);
            Debug.Log("user doesnot exist");
        }
        else
        {
			
            Debug.Log("user exist");
        }
        ServerController.Instance.PopulateDailyLevelData();
        MainMenuController.Instance.ShowMainMenuScreen ();

    }
}
