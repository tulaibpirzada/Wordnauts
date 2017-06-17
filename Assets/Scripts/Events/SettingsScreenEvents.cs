using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreenEvents : MonoBehaviour {

   public void ScreenTapped()
    {
        LocalSettingsController.Instance.Save();
        MainMenuController.Instance.ShowMainMenuScreen();
    }
    public void SFXToggleChanged()
    {
        SettingScreenController.Instance.SFXToggleHandler();


    }
    public void AlertsToggleChanged()
    {
        SettingScreenController.Instance.AlertsToggleHandler();
    }
    public void FeedbackButtonPressed()
    {

    }
    public void RateUsButtonPressed()
    {

    }

}
