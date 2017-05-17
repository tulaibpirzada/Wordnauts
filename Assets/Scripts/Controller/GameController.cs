using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> {

	GameReferences gameRef;
	GameObject gameContextObject;

	//Loads the game
	public void RetrieveDataFromServer(GameObject gameObject)
	{
		gameContextObject = gameObject;
		gameRef = gameContextObject.GetComponent<GameReferences> ();
		RetrieveData.Instance.GetDailyLevels(LoadGame);

	}

	public void LoadGame() {
		MainMenuController.Instance.ShowMainMenuScreen (gameRef.mainMenuRef);
	}
}
