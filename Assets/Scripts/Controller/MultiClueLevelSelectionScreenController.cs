using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiClueLevelSelectionScreenController : Singleton<MultiClueLevelSelectionScreenController> {

	MultiClueLevelSelectionScreenReferences multiClueLevelSelectionScreenRef;
	private List<GameObject> levelItemList;

	public void LoadScreen() {
		GameObject levelSelectionGameObject = ScreenTransitionManager.Instance.ShowScreen (GameConstants.Screens.MULTI_CLUE_LEVEL_SELECTION_SCREEN);
		multiClueLevelSelectionScreenRef = levelSelectionGameObject.GetComponent<MultiClueLevelSelectionScreenReferences> ();
		PopulateScrollView ();
	}

	public void SlideBackToMainMenu() {
		ResetScrollView ();
		MainMenuController.Instance.ShowMainMenuScreen();
	}

	private void ResetScrollView() {
		foreach (GameObject levelItem in levelItemList) {
			Destroy (levelItem);
		}
		levelItemList.Clear ();
	}

	private void PopulateScrollView() {
		levelItemList = new List<GameObject> ();
		for (int index = 0; index < MultipleMultiPackModel.Instance.TotalLevels; index++) {
			GameObject listItemGameObject = Instantiate(multiClueLevelSelectionScreenRef.levelListItem) as GameObject;
			listItemGameObject.transform.SetParent(multiClueLevelSelectionScreenRef.scrollView.content, true);
			listItemGameObject.transform.localPosition = Vector3.zero;
			listItemGameObject.transform.localScale = Vector3.one;
			levelItemList.Add (listItemGameObject);
			LevelListItemReferences levelListItemRef = listItemGameObject.GetComponent<LevelListItemReferences> ();
			levelListItemRef.titleLabel.text = "Level " + (index + 1).ToString ();
			levelListItemRef.levelListType = LevelListItemReferences.LevelListType.MultiClueLevelList;
//			//			if (index < PlayerModel.Instance.singleClue.PackNo) {
//			//				puzzlePackListItemRef.tickIcon.SetActive(true);
//			//				puzzlePackListItemRef.newIcon.SetActive(false);
//			//				puzzlePackListItemRef.arrowIcon.SetActive(false);
//			//				puzzlePackListItemRef.lockIcon.SetActive(false);
//			//				puzzlePackListItemRef.puzzlePackModel = MultiplePackModel.Instance.packsList [index];
//			//			} else if (index == PlayerModel.Instance.singleClue.PackNo) {
			levelListItemRef.tickIcon.SetActive(false);
			levelListItemRef.newIcon.SetActive(true);
			levelListItemRef.arrowIcon.SetActive(true);
			levelListItemRef.lockIcon.SetActive(false);
			levelListItemRef.puzzleModel = MultipleMultiPackModel.Instance.puzzleModelList[index];
			//			} else if (index > PlayerModel.Instance.singleClue.PackNo) {
			//				puzzlePackListItemRef.tickIcon.SetActive(false);
			//				puzzlePackListItemRef.newIcon.SetActive(false);
			//				puzzlePackListItemRef.arrowIcon.SetActive(false);
			//				puzzlePackListItemRef.lockIcon.SetActive(true);
			//				puzzlePackListItemRef.puzzlePackModel = null;
			//			}
		}
	}

	public void ShowPuzzleScreen(LevelListItemReferences levelListItemRef) {
		ResetScrollView ();
		GamePlayScreenController.Instance.LoadScreen (levelListItemRef.puzzleModel);
	}
}
