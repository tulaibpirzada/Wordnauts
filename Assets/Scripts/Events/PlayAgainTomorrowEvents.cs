using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayAgainTomorrowEvents : MonoBehaviour
{
    public void screenTapped()
    {
        MainMenuController.Instance.ShowMainMenuScreen();
    }
    
}

