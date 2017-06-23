using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseFailurePopupController : Singleton<PurchaseFailurePopupController>
{
    PurchaseFailurePopupReferences purchasefailurePopupRef;
    public void LoadScreen()
    {
        GameObject purchasefailurePopupGameObject = ScreenTransitionManager.Instance.ShowScreen(GameConstants.Screens.PURCHASE_FAILURE_POPUP);
        purchasefailurePopupRef = purchasefailurePopupGameObject.GetComponent<PurchaseFailurePopupReferences>();
    }

}
