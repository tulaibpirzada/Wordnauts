using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleClueLevelSelectionScreenController : Singleton<SingleClueLevelSelectionScreenController> {

	SingleClueLevelSelectionScreenReferences singleClueLevelSelectionScreenRef;
	private List<GameObject> levelItemList;
	private PuzzlePackModel puzzlePackModel;

	public void LoadScreen(PuzzlePackModel puzzlePackModel) {
		this.puzzlePackModel = puzzlePackModel;
		GameObject levelSelectionGameObject = ScreenTransitionManager.Instance.ShowScreen (GameConstants.Screens.SINGLE_CLUE_LEVEL_SELECTION_SCREEN);
		singleClueLevelSelectionScreenRef = levelSelectionGameObject.GetComponent<SingleClueLevelSelectionScreenReferences> ();
		PopulateScrollView ();
	}

	public void SlideBackToMainMenu() {
		foreach (GameObject levelItem in levelItemList) {
			Destroy (levelItem);
		}
		levelItemList.Clear ();
		MainMenuController.Instance.ShowMainMenuScreen();
	}

	private void PopulateScrollView() {
		levelItemList = new List<GameObject> ();
		for (int index = 0; index < puzzlePackModel.TotalLevels; index++) {
			GameObject listItemGameObject = Instantiate(singleClueLevelSelectionScreenRef.levelListItem) as GameObject;
			listItemGameObject.transform.SetParent(singleClueLevelSelectionScreenRef.scrollView.content, true);
			listItemGameObject.transform.localPosition = Vector3.zero;
			listItemGameObject.transform.localScale = Vector3.one;
			levelItemList.Add (listItemGameObject);
			LevelListItemReferences levelListItemRef = listItemGameObject.GetComponent<LevelListItemReferences> ();
			levelListItemRef.titleLabel.text = "Level " + (index + 1).ToString ();
//			if (index < PlayerModel.Instance.singleClue.PackNo) {
//				puzzlePackListItemRef.tickIcon.SetActive(true);
//				puzzlePackListItemRef.newIcon.SetActive(false);
//				puzzlePackListItemRef.arrowIcon.SetActive(false);
//				puzzlePackListItemRef.lockIcon.SetActive(false);
//				puzzlePackListItemRef.puzzlePackModel = MultiplePackModel.Instance.packsList [index];
//			} else if (index == PlayerModel.Instance.singleClue.PackNo) {
			levelListItemRef.tickIcon.SetActive(false);
			levelListItemRef.newIcon.SetActive(true);
			levelListItemRef.arrowIcon.SetActive(true);
			levelListItemRef.lockIcon.SetActive(false);
			levelListItemRef.singleClueModel = puzzlePackModel.levelsList[index];
//			} else if (index > PlayerModel.Instance.singleClue.PackNo) {
//				puzzlePackListItemRef.tickIcon.SetActive(false);
//				puzzlePackListItemRef.newIcon.SetActive(false);
//				puzzlePackListItemRef.arrowIcon.SetActive(false);
//				puzzlePackListItemRef.lockIcon.SetActive(true);
//				puzzlePackListItemRef.puzzlePackModel = null;
//			}
		}
	}

	public void ShowPuzzleScreen() {
		
	}
}
