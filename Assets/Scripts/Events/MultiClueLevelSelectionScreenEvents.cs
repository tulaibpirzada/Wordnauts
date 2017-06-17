using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiClueLevelSelectionScreenEvents : MonoBehaviour {

    public void BackButtonTapped()
    {
        MultiClueLevelSelectionScreenController.Instance.SlideBackToMainMenu();
    }
}
