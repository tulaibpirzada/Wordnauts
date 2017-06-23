using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseSuccessPopupController : Singleton<PurchaseSuccessPopupController>
{
    PurchaseSuccessPopupReferences purchaseSuccessPopupRef;
    public void LoadScreen()
    {
        GameObject purchaseSuccessPopupGameObject = ScreenTransitionManager.Instance.ShowScreen(GameConstants.Screens.PURCHASE_SUCCESS_POPUP);
        purchaseSuccessPopupRef = purchaseSuccessPopupGameObject.GetComponent<PurchaseSuccessPopupReferences>();
    }

}
