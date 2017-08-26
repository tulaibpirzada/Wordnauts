using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayScreenEvents : MonoBehaviour {
	public void backButtonPressed()
	{
        GamePlayScreenController.Instance.SlideBackToMainMenu();
	}

    public void hintButtonPressed()
    {
        GamePlayScreenController.Instance.HandleHints();   
    }

    public void LeftButtonTapped()
    {
        GamePlayScreenController.Instance.ShowPreviousSolutionAndClue();
    }

	public void RightButtonTapped()
	{
        GamePlayScreenController.Instance.ShowNextSolutionAndClue();
	}

	public void MysteryClueTapped() {
		GamePlayScreenController.Instance.ShowRevealCluePopup ();
	}

	public void ResetButtonTapped() {
		GamePlayScreenController.Instance.ResetScreen ();
	}

}
