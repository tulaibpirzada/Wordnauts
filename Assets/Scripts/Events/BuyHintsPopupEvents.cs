using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHintsPopupEvents : MonoBehaviour {
    
	public void ScreenTapped()
    {
        BuyHintsPopupController.Instance.SlideBackToMainMenu();
    }
}
