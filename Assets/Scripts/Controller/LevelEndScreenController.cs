using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndScreenController : Singleton<LevelEndScreenController> {

	LevelEndScreenReferences levelEndScreenRef;
    public PuzzleModel puzzleModel;

	private void SendUpdateToServer() {
		
		//update percentage
		PlayerModel.Instance.UpdateCompletionPercentage();
        //update stars & hints
        puzzleModel.UpdateReward();

        //update level no. / puzzle pack
        if (puzzleModel.PuzzleType==1)
        {
            PlayerModel.Instance.DailyLevelComplete();
        
        }
        else if (puzzleModel.PuzzleType==2)
        {
           PlayerModel.Instance.SingleClueLevelComplete();
            
        }
        else
        {
            PlayerModel.Instance.MultiClueLevelComplete();
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

    public void HandleNavigation()
    {

            
            // if the puzzle just played is completed first time and is single clue
            if (this.puzzleModel.PuzzleType == 1)
        {
            MainMenuController.Instance.ShowMainMenuScreen();
        }
        else if (this.puzzleModel.PuzzleType == 2)
        {
            int status = PlayerModel.Instance.CheckSingleClueStageComplete();
            if (status == 1 || status==0)
            {

                SingleCluePuzzleSelectionScreenController.Instance.LoadScreen();
            }
            else if (status == 2)
            {
                //this.puzzleModel = MultiplePackModel.Instance.packsList[PlayerModel.Instance.singleClue.PackNo].levelsList[PlayerModel.Instance.singleClue.LevelNo];
                SingleClueLevelSelectionScreenController.Instance.LoadScreen(MultiplePackModel.Instance.packsList[PlayerModel.Instance.singleClue.PackNo]);
                // LevelStartScreenController.Instance.ShowScreen(this.puzzleModel);

            }
            else
            {
                MainMenuController.Instance.ShowMainMenuScreen();
            }
        }
            
            else
            {
                if (PlayerModel.Instance.CheckStageComplete(PlayerModel.Instance.multiClue.LevelNo, MultipleMultiPackModel.Instance.TotalLevels))
                {
                    this.puzzleModel = MultipleMultiPackModel.Instance.puzzleModelList[PlayerModel.Instance.multiClue.LevelNo];
                    MultiClueLevelSelectionScreenController.Instance.LoadScreen();
                   
                }
                else
                {
                    MainMenuController.Instance.ShowMainMenuScreen();
                }

            }



        }
    
    
}
