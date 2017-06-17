using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScreenController : Singleton<SettingScreenController>
{
    SettingsScreenReferences settingsScreenRef;
    public static LocalSettings GameSettings = new LocalSettings();
    public void LoadScreen()
    {
        GameObject settingsScreenGameObject = ScreenTransitionManager.Instance.ShowScreen(GameConstants.Screens.SETTINGS_SCREEN);
        settingsScreenRef = settingsScreenGameObject.GetComponent<SettingsScreenReferences>();
        LoadOldSettings();

    }
   public void SFXToggleHandler()
    {
        if (settingsScreenRef.sfx.image.sprite == settingsScreenRef.toggleImageOn)
        {
            settingsScreenRef.sfx.image.sprite = settingsScreenRef.toggleImageOff;
            LocalSettingsController.Instance.SetSFxControl(false);
        }
        else
        {
            settingsScreenRef.sfx.image.sprite = settingsScreenRef.toggleImageOn;
            LocalSettingsController.Instance.SetSFxControl(true);
        }
        
    }
    public void AlertsToggleHandler()
    {
        if (settingsScreenRef.alert.image.sprite == settingsScreenRef.toggleImageOn)
        {
            settingsScreenRef.alert.image.sprite = settingsScreenRef.toggleImageOff;
            LocalSettingsController.Instance.SetAlertsControl(false);
        }
        else
        {
            settingsScreenRef.alert.image.sprite = settingsScreenRef.toggleImageOn;
            LocalSettingsController.Instance.SetAlertsControl(true);
        }
    }

    public void LoadOldSettings()
    {
        if (LocalSettingsController.Instance.Load(ref GameSettings))
        {
            if(LocalSettingsController.Instance.IsSFXOn(GameSettings))
            {
                settingsScreenRef.sfx.image.sprite = settingsScreenRef.toggleImageOn;
            }
            else
            {
                settingsScreenRef.sfx.image.sprite = settingsScreenRef.toggleImageOff;
            }

            if(LocalSettingsController.Instance.IsAlertsOn(GameSettings))
            {
                settingsScreenRef.alert.image.sprite = settingsScreenRef.toggleImageOn;
            }
            else
            {
                settingsScreenRef.alert.image.sprite = settingsScreenRef.toggleImageOff;
            }
        }
    }
}

