using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEvents : MonoBehaviour {

	public void DailyPuzzleButtonTapped()
	{
		MainMenuController.Instance.CheckAndLoadDailyPuzzle ();
	}

	public void SingleCluePuzzleButtonTapped()
	{
		MainMenuController.Instance.ShowSingleCluePuzzleSelectionScreen ();
	}

	public void MultiCluePuzzleButtonTapped()
	{
		MainMenuController.Instance.ShowMultiCluePuzzleSelectionScreen ();
	}

	public void GetMoreHintsButtonTapped()
	{
		MainMenuController.Instance.ShowGetMoreHintsPopup ();
	}

	public void SettingsButtonTapped()
	{
		MainMenuController.Instance.ShowSettingsPopup ();
	}
}
