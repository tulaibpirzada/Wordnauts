using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoMoreDailyLevelPopupEvents : MonoBehaviour {
    
	public void ScreenTapped()
    {
        MainMenuController.Instance.ShowMainMenuScreen();
    }
}
