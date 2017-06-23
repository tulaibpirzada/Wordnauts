using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseSuccessPopupEvents : MonoBehaviour {
   public void ScreenTapped()
    {
        MainMenuController.Instance.ShowMainMenuScreen();
    }
}
