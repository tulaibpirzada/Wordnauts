using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : Singleton<MainMenuController> {

	MainMenuReferences mainMenuRef;

	public void ShowMainMenuScreen(MainMenuReferences mainMenuReferences)
	{
		mainMenuRef = mainMenuReferences;
		mainMenuRef.gameObject.SetActive (true);
	}

	public void HideGameStartScreen ()
	{
		mainMenuRef.gameObject.SetActive (false);
	}
}
