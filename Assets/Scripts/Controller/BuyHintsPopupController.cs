using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyHintsPopupController : Singleton<BuyHintsPopupController>
{
    BuyHintsPopupReferences buyHintsPopupRef;
    public List<GameObject> levelItemList;

    public void LoadScreen()
    {
        GameObject buyHintsPopupGameObject = ScreenTransitionManager.Instance.ShowScreen(GameConstants.Screens.BUY_HINTS_POPUP);
        buyHintsPopupRef = buyHintsPopupGameObject.GetComponent<BuyHintsPopupReferences>();
        PopulateScrollView();
    }

    private void PopulateScrollView()
    {
        levelItemList = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject listItemGameObject = Instantiate(buyHintsPopupRef.hintListItem) as GameObject;
            listItemGameObject.transform.SetParent(buyHintsPopupRef.scrollView.content, true);
            listItemGameObject.transform.localPosition = Vector3.zero;
            listItemGameObject.transform.localScale = Vector3.one;
            levelItemList.Add(listItemGameObject);
          /*  GameObject dividePanel = Instantiate(buyHintsPopupRef.divider) as GameObject;
            dividePanel.transform.SetParent(buyHintsPopupRef.scrollView.content, true);
            dividePanel.transform.localPosition = Vector3.zero;
            dividePanel.transform.localScale = Vector3.one;
           // RectTransform rt = dividePanel.GetComponent<RectTransform>();
           // rt.sizeDelta = new Vector2(839, 10);
            levelItemList.Add(dividePanel);*/
            buyHintsPopupRef.hintCount.text = "2 HINTS".ToString();
            buyHintsPopupRef.price.text = "10$".ToString();
        }
    }
    public void SlideBackToMainMenu()
    {
        ResetScrollView();
        MainMenuController.Instance.ShowMainMenuScreen();
    }

    private void ResetScrollView()
    {
        foreach (GameObject levelItem in levelItemList)
        {
            Destroy(levelItem);
        }
        levelItemList.Clear();
        
    }
}