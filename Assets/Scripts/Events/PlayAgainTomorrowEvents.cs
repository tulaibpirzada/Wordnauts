using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class PlayAgainTomorrowEvents : MonoBehaviour
{
    public void screenTapped()
    {
        LevelEndScreenController.Instance.SlideBackToMainMenu();
    }
}

