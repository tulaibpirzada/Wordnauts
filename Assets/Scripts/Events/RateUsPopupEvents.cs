using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RateUsPopupEvents: MonoBehaviour
{
   
    public void ScreenTapped()
    {
		RateUsPopUpController.Instance.RemovePopup();
    }
    public void SureButtonPressed()
    {
        RateUsPopUpController.Instance.SaveRating();
        SettingScreenController.Instance.LoadScreen();
    }
}