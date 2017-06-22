using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyHintsPopupController : Singleton<BuyHintsPopupController>
{
    BuyHintsPopupReferences buyHintsPopupRef;
    public void LoadScreen()
    {
        GameObject buyHintsPopupGameObject = ScreenTransitionManager.Instance.ShowScreen(GameConstants.Screens.BUY_HINTS_POPUP);
        buyHintsPopupRef = buyHintsPopupGameObject.GetComponent<BuyHintsPopupReferences>();
        PopulateScrollView();
    }

    private void PopulateScrollView()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject listItemGameObject = Instantiate(buyHintsPopupRef.hintListItem) as GameObject;
            listItemGameObject.transform.SetParent(buyHintsPopupRef.scrollView.content, true);
            listItemGameObject.transform.localPosition = Vector3.zero;
            listItemGameObject.transform.localScale = Vector3.one;
            //BuyHintsPopupReferences hintListItemRef = listItemGameObject.GetComponent<BuyHintsPopupReferences>();
            //hintListItemRef.hintListItem.GetComponent < "Item Name" >;
        }
    }
}