using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePackLockedByPrestigeScreenController : Singleton<PuzzlePackLockedByPrestigeScreenController>
{
    PuzzlePackLockedByPrestigeScreenReferences puzzlePackLockedByPrestigeScreenRef;
    public void LoadScreen()
    {
        GameObject puzzlePackLockedByPrestigeGameObject = ScreenTransitionManager.Instance.ShowScreen(GameConstants.Screens.PUZZLE_PACK_LOCKED_BY_PRESTIGE_POPUP);
        puzzlePackLockedByPrestigeScreenRef = puzzlePackLockedByPrestigeGameObject.GetComponent<PuzzlePackLockedByPrestigeScreenReferences>();
        puzzlePackLockedByPrestigeScreenRef.star.text = PlayerModel.Instance.stars.ToString();
        int packNo = PlayerModel.Instance.singleClue.PackNo + 1;
        int prestigePoints = MultiplePackModel.Instance.packsList[packNo].RequiredPointsToUnlock;
        puzzlePackLockedByPrestigeScreenRef.Message.text = "You are "+prestigePoints.ToString()+" prestige points short of unlocking Puzzle Pack # "+(packNo+1).ToString();
        
        //int puzzlePackNo

       // ScreenTransitionManager.Instance.ShowScreen(GameConstants.Screens.PUZZLE_PACK_LOCKED_BY_PRESTIGE_POPUP);


    }
}
