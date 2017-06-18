using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePackLockedByPrestigeScreenEvents : MonoBehaviour {

	public void ScreenTapped()
    {
        MainMenuController.Instance.ShowMainMenuScreen();
    }
}
