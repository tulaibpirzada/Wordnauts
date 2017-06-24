using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealCluePopupEvents : MonoBehaviour {

    public void ScreenTapped()
    {
        MainMenuController.Instance.ShowMainMenuScreen();
    }

    public void MysteryClueTapped()
    {
        RevealCluePopupController.Instance.LoadScreen();
    }
}
