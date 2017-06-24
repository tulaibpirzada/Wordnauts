using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTransitionManager : Singleton<ScreenTransitionManager> {
	GameReferences gameRef;
	GameObject currentlyVisibleScreen;
	GameObject screenToBeRemoved;
	Dictionary<GameConstants.Screens,GameObject> screenReferencesDictionary;

	public void SetScreenReferences(GameObject gameContextObject) {
		gameRef = gameContextObject.GetComponent<GameReferences> ();
		screenReferencesDictionary = new Dictionary<GameConstants.Screens, GameObject> ();
        screenReferencesDictionary.Add (GameConstants.Screens.SPLASH_SCREEN, gameRef.splashScreenRef.gameObject);
		screenReferencesDictionary.Add (GameConstants.Screens.MAIN_MENU_SCREEN, gameRef.mainMenuRef.gameObject);
		screenReferencesDictionary.Add (GameConstants.Screens.SINGLE_CLUE_PUZZLE_PACK_SELECTION_SCREEN, gameRef.singleCluePuzzleSelectionRef.gameObject);
		screenReferencesDictionary.Add (GameConstants.Screens.SINGLE_CLUE_LEVEL_SELECTION_SCREEN, gameRef.singleClueLevelSelectionRef.gameObject);
		screenReferencesDictionary.Add (GameConstants.Screens.MULTI_CLUE_LEVEL_SELECTION_SCREEN, gameRef.multiClueLevelSelectionRef.gameObject);
        screenReferencesDictionary.Add (GameConstants.Screens.LEVEL_START_SCREEN, gameRef.levelStartScreenRef.gameObject);
        screenReferencesDictionary.Add (GameConstants.Screens.GAME_PLAY_SCREEN, gameRef.gamePlayScreenRef.gameObject);
		screenReferencesDictionary.Add (GameConstants.Screens.LEVEL_END_SCREEN, gameRef.levelEndScreenRef.gameObject);
        screenReferencesDictionary.Add(GameConstants.Screens.SETTINGS_SCREEN, gameRef.settingsScreenRef.gameObject);
		screenReferencesDictionary.Add(GameConstants.Screens.NO_MORE_DAILY_LEVELS_POPUP, gameRef.noMoreDailyLevelPopupRef.gameObject);
        screenReferencesDictionary.Add(GameConstants.Screens.PUZZLE_PACK_LOCKED_BY_PRESTIGE_POPUP, gameRef.puzzlePackLockedByPrestigeScreenRef.gameObject);
        screenReferencesDictionary.Add(GameConstants.Screens.BUY_HINTS_POPUP, gameRef.buyHintsPopupRef.gameObject);
        screenReferencesDictionary.Add(GameConstants.Screens.RATE_US_POPUP_SCREEN,gameRef.rateUsPopupRef.gameObject);
        screenReferencesDictionary.Add(GameConstants.Screens.PURCHASE_FAILURE_POPUP, gameRef.purchaseFailurePopupRef.gameObject);
        screenReferencesDictionary.Add(GameConstants.Screens.PURCHASE_SUCCESS_POPUP, gameRef.purchaseSuccessPopupRef.gameObject);
        screenReferencesDictionary.Add(GameConstants.Screens.REVEAL_CLUE_POPUP, gameRef.revealCluePopupRef.gameObject);
    }

	public GameObject ShowScreen(GameConstants.Screens screen) {
		GameObject screenToBeShown = null;
		if (screenReferencesDictionary.TryGetValue (screen, out screenToBeShown)) {
			if (currentlyVisibleScreen != null) {
				screenToBeRemoved = currentlyVisibleScreen;
				currentlyVisibleScreen = screenToBeShown;
				currentlyVisibleScreen.SetActive (true);
				screenToBeRemoved.SetActive (false);
			} else {
				currentlyVisibleScreen = screenToBeShown;
				currentlyVisibleScreen.gameObject.SetActive (true);
			}
		} else {
			//error
		}
		return currentlyVisibleScreen;
	}
}
