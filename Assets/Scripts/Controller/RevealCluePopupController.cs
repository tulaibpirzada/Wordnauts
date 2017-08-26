using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealCluePopupController : Singleton<RevealCluePopupController>
{
    RevealCluePopupReferences revealCluePopupRef;
    public void LoadPopup()
    {
		GameObject revealCluePopupGameObject = ScreenTransitionManager.Instance.ShowPopup(GameConstants.Screens.REVEAL_CLUE_POPUP);
        revealCluePopupRef = revealCluePopupGameObject.GetComponent<RevealCluePopupReferences>();
    }

	public void RemovePopup() {
		ScreenTransitionManager.Instance.RemovePopup ();
	}

}
