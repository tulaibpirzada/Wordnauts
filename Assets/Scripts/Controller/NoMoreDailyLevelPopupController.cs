using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMoreDailyLevelPopupController : Singleton<NoMoreDailyLevelPopupController> {
	NoMoreDailyLevelPopupReferences noMoreDailyLevelPopupRef;
	public void LoadPopup()
	{
		GameObject noMoreDailyLevelPopupGameObject = ScreenTransitionManager.Instance.ShowPopup(GameConstants.Screens.NO_MORE_DAILY_LEVELS_POPUP);
		noMoreDailyLevelPopupRef = noMoreDailyLevelPopupGameObject.GetComponent<NoMoreDailyLevelPopupReferences>();

        noMoreDailyLevelPopupRef.dayLabel.text = System.DateTime.Now.DayOfWeek.ToString();
        noMoreDailyLevelPopupRef.dateLabel.text = System.DateTime.Now.Day.ToString();

    }

	public void RemovePopup() {
		ScreenTransitionManager.Instance.RemovePopup ();
	}
}
