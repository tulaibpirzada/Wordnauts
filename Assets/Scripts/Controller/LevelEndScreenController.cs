using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndScreenController : Singleton<LevelEndScreenController> {

	LevelEndScreenReferences levelEndScreenRef;
    public PuzzleModel puzzleModel;

	private void SendUpdateToServer() {
		
		//update percentage
		PlayerModel.Instance.UpdateCompletionPercentage();
		
		//update level no. / puzzle pack
        if (puzzleModel.PuzzleType==1)
        {
            if(!PlayerModel.Instance.DailyLevelComplete())
            {
                //Show NO more levels to play
            }
        
        }
        else if (puzzleModel.PuzzleType==2)
        {
            int result=PlayerModel.Instance.SingleClueLevelComplete();
            if (result==-1)
            {
                //show No more levels to play (All packs are completed)
            }
            else if(result==0)
            {
                //Prestige points are lower than the required ones screen
                
            }
            else if(result==1)
            {
                // all levels of current pack are finished

            }
            else
            {
                // do nothing just unlock the next level
            }
        }
        else
        {
            if (!PlayerModel.Instance.MultiClueLevelComplete())
            {
                //Show NO more levels to play
            }
        }
		//send update call
		SendData.Instance.UpdatePlayerData();
	}


	public void LoadScreen(PuzzleModel puzzleModel)
    {
		this.puzzleModel = puzzleModel;
        GameObject levelEndGameObject = ScreenTransitionManager.Instance.ShowScreen(GameConstants.Screens.LEVEL_END_SCREEN);
        levelEndScreenRef = levelEndGameObject.GetComponent<LevelEndScreenReferences>();
        if (this.puzzleModel.LevelAlreadyPlayed == false)
        {
            SendUpdateToServer();
            levelEndScreenRef.Star.text = "+" + puzzleModel.PrestigePoints.ToString();
        }
        else
        {
            levelEndScreenRef.Star.text = 0.ToString();
        }
		  
	}

	public void SlideBackToMainMenu() {

        //update stars & hints
        if (!this.puzzleModel.LevelAlreadyPlayed)
        {
            puzzleModel.UpdateReward();
        }
        MainMenuController.Instance.ShowMainMenuScreen();
        
    }
    
}
