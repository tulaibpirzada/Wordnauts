using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> {

	//Loads the game
	public void RetrieveDataFromServer()
	{
       // AuthenticateUsers.Instance.getuser();
        //Initialize the device ID in the start
        //It will uniquely identify each user at the server
        PlayerModel.Instance.SetDeviceID();

        ScreenTransitionManager.Instance.ShowScreen (GameConstants.Screens.SPLASH_SCREEN);
		RetrieveData.Instance.LoadGameData(LoadGame);
        

    }

	public void LoadGame()
    {
        if (!DatabaseModel.Instance.userExists)
        {
            
            PlayerModel.Instance.SetUpPlayerData();
            SendData.Instance.uploadPlayerData();
            Debug.Log("user doesnot exist");
        }
        else
        {
			
            Debug.Log("user exist");
            PlayerModel.Instance.GetPlayerDataFromSnapshot();
            PlayerModel.Instance.GetPlayerDailyLevelDataFromSnapshot();
            PlayerModel.Instance.GetPlayerSingleClueDataFromSnapshot();
            PlayerModel.Instance.GetPlayerMultiClueDataFromSnapshot();
        }
        //Debug.Log(PlayerModel.Instance.dailyLevel.LevelNo);
        //ServerController.Instance.PopulateDailyLevelData();
        Debug.Log(DatabaseModel.Instance.dailyLevelSnapshot);
        Debug.Log(DatabaseModel.Instance.singleClueSnapshot);
        Debug.Log(DatabaseModel.Instance.multiClueSnapshot);
        DailyLevelModel.Instance.Populate();
        SingleClueModel.Instance.Populate();
        MultiClueModel.Instance.Populate();
        MainMenuController.Instance.ShowMainMenuScreen ();

    }
}
