using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCluePuzzleSelectionScreenEvents : MonoBehaviour {
    public void backButtonPressed() {
        SingleCluePuzzleSelectionScreenController.Instance.SlideBackToMainMenu();
    }
}
