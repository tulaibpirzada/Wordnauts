using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseFailurePopupEvents : MonoBehaviour {

    public void ScreenTapped()
    {
		PurchaseFailurePopupController.Instance.RemovePopup();
    }
}
