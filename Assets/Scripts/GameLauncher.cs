using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  GameLauncher : MonoBehaviour
{

  // Use this for initialization
   void Start()
   {
		ScreenTransitionManager.Instance.SetScreenReferences (gameObject);
		GameController.Instance.RetrieveDataFromServer ();
   }


}


