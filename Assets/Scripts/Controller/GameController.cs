using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> {

	//Loads the game
	public void RetrieveDataFromServer()
	{

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
            SendData.Instance.UploadPlayerData();
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

       DailyLevelModel.Instance.Populate();
        MultiplePackModel.Instance.Populate();
        MultipleMultiPackModel.Instance.Populate();
        PlayerModel.Instance.UpdateCompletionPercentage();

/*        SendData.Instance.UpdatePlayerData();*/
        MainMenuController.Instance.ShowMainMenuScreen ();

    }
}
