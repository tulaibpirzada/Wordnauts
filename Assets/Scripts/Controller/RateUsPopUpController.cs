using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateUsPopUpController : Singleton<RateUsPopUpController>
{
    RateUsPopupReferences rateUsPopupRef;
    public void LoadPopup()
    {
		GameObject rateUsPopupGameObject = ScreenTransitionManager.Instance.ShowPopup(GameConstants.Screens.RATE_US_POPUP_SCREEN);
        rateUsPopupRef = rateUsPopupGameObject.GetComponent<RateUsPopupReferences>();
    }
   public void SaveRating()
    {
        PlayerModel.Instance.appRating = 5;
    }

	public void RemovePopup() {
		ScreenTransitionManager.Instance.RemovePopup ();
	}
}

