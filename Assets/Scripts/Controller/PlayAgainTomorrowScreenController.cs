using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgainTomorrowScreenController : Singleton<PlayAgainTomorrowScreenController>
{
    PlayAgainTomorrowReferences playAgainTomorrowRef;
    public void LoadScreen()
    {
        GameObject playAgainTomorrowGameObject = ScreenTransitionManager.Instance.ShowScreen(GameConstants.Screens.PLAY_AGAIN_TOMORROW);
        playAgainTomorrowRef= playAgainTomorrowGameObject.GetComponent<PlayAgainTomorrowReferences>();
     
    }
   

}

