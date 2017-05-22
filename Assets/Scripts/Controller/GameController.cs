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
            PlayerModel.Instance.SetPlayerDataFromSnapshot();
            PlayerModel.Instance.SetPlayerDailyLevelDataFromSnapshot();
           
        }
        //Debug.Log(PlayerModel.Instance.dailyLevel.LevelNo);
        ServerController.Instance.PopulateDailyLevelData();
     
        MainMenuController.Instance.ShowMainMenuScreen ();

    }
}
