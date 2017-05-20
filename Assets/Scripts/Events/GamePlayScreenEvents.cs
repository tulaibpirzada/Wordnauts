using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayScreenEvents : MonoBehaviour {
	public void backButtonPressed()
	{
        GamePlayScreenController.Instance.SlideBackToMainMenu();
	}
}
