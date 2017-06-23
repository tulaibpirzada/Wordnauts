using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateUsPopUpController : Singleton<RateUsPopUpController>
{
    RateUsPopupReferences rateUsPopupRef;
    public void LoadScreen()
    {
        GameObject rateUsPopupGameObject = ScreenTransitionManager.Instance.ShowScreen(GameConstants.Screens.RATE_US_POPUP_SCREEN);
        rateUsPopupRef = rateUsPopupGameObject.GetComponent<RateUsPopupReferences>();
    }
   public void SaveRating()
    {
        PlayerModel.Instance.appRating = 5;
    }
}

