using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealCluePopupEvents : MonoBehaviour {

    public void ScreenTapped()
    {
		RevealCluePopupController.Instance.RemovePopup();
    }
}
