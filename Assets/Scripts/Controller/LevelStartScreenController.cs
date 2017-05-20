using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartScreenController : Singleton<LevelStartScreenController> {
    LevelStartScreenReferences levelStartScreenRef;

    public void ShowScreen() {
        GameObject levelStartScreenGameObject = ScreenTransitionManager.Instance.ShowScreen(GameConstants.Screens.LEVEL_START_SCREEN);
		levelStartScreenRef = levelStartScreenGameObject.GetComponent<LevelStartScreenReferences>();
    }

    public void LoadPuzzle() {
        GamePlayScreenController.Instance.LoadScreen();
    }
}
