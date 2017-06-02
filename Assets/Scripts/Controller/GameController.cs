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

       DailyLevelModel.Instance.Populate();
        MultiplePackModel.Instance.Populate();
        MultipleMultiPackModel.Instance.Populate();
        PlayerModel.Instance.UpdateCompletionPercentage();
      /*  PuzzleModel model = new PuzzleModel();
        model.PrestigePoints = 2;
        model.Hints = 4;
        model.UpdateReward();
        SendData.Instance.UpdatePlayerData();*/
        MainMenuController.Instance.ShowMainMenuScreen ();

    }
}
