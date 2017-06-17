using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreenEvents : MonoBehaviour {

    public void screenTapped()
    {
        MainMenuController.Instance.ShowMainMenuScreen();
    }


}
