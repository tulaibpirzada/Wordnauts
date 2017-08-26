using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseFailurePopupController : Singleton<PurchaseFailurePopupController>
{
    PurchaseFailurePopupReferences purchasefailurePopupRef;
    public void LoadPopup()
    {
		GameObject purchasefailurePopupGameObject = ScreenTransitionManager.Instance.ShowPopup(GameConstants.Screens.PURCHASE_FAILURE_POPUP);
        purchasefailurePopupRef = purchasefailurePopupGameObject.GetComponent<PurchaseFailurePopupReferences>();
    }

	public void RemovePopup() {
		ScreenTransitionManager.Instance.RemovePopup ();
	}

}
