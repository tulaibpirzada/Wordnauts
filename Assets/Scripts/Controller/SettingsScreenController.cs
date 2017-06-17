using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScreenController : Singleton<SettingScreenController>
{
    SettingsScreenReferences settingsScreenRef;
    public void LoadScreen()
    {
        GameObject settingsScreenGameObject = ScreenTransitionManager.Instance.ShowScreen(GameConstants.Screens.SETTINGS_SCREEN);
        settingsScreenRef = settingsScreenGameObject.GetComponent<SettingsScreenReferences>();
     
    }
   public void SFXToggleHandler()
    {
        if(LocalSettingsController.Instance.Load())
        {
            
        }
    }

}

