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
        
       // Transform hintButtonTransform = Ref.hintsButton.transform;
        GamePlayScreenController.Instance.HandleHints();
        
    }
}
