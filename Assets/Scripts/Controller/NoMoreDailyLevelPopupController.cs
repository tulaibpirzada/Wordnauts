using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMoreDailyLevelPopupController : Singleton<NoMoreDailyLevelPopupController> {
	NoMoreDailyLevelPopupReferences noMoreDailyLevelPopupRef;
	public void LoadScreen()
	{
		GameObject noMoreDailyLevelPopupGameObject = ScreenTransitionManager.Instance.ShowScreen(GameConstants.Screens.NO_MORE_DAILY_LEVELS_POPUP);
		noMoreDailyLevelPopupRef = noMoreDailyLevelPopupGameObject.GetComponent<NoMoreDailyLevelPopupReferences>();

	}
}
