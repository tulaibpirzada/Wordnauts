using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreenEvents : MonoBehaviour {

    public void ScreenTapped()
    {
        MainMenuController.Instance.ShowMainMenuScreen();
    }


}
