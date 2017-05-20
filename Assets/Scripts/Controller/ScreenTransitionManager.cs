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
		screenReferencesDictionary.Add (GameConstants.Screens.SINGLE_CLUE_SELECTION_SCREEN, gameRef.singleCluePuzzleSelectionRef.gameObject);
        screenReferencesDictionary.Add(GameConstants.Screens.LEVEL_START_SCREEN, gameRef.levelStartScreenRef.gameObject);

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
