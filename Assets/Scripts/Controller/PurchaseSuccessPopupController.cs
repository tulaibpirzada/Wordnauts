using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseSuccessPopupController : Singleton<PurchaseSuccessPopupController>
{
    PurchaseSuccessPopupReferences purchaseSuccessPopupRef;
    public void LoadPopup()
    {
		GameObject purchaseSuccessPopupGameObject = ScreenTransitionManager.Instance.ShowPopup(GameConstants.Screens.PURCHASE_SUCCESS_POPUP);
        purchaseSuccessPopupRef = purchaseSuccessPopupGameObject.GetComponent<PurchaseSuccessPopupReferences>();
    }

	public void RemovePopup() {
		ScreenTransitionManager.Instance.RemovePopup ();
	}
}
