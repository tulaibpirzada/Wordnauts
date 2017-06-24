using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealCluePopupController : Singleton<RevealCluePopupController>
{
    RevealCluePopupReferences revealCluePopupRef;
    public void LoadScreen()
    {
        GameObject revealCluePopupGameObject = ScreenTransitionManager.Instance.ShowScreen(GameConstants.Screens.REVEAL_CLUE_POPUP);
        revealCluePopupRef = revealCluePopupGameObject.GetComponent<RevealCluePopupReferences>();

    }

}
