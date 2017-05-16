using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class  GameLauncher : MonoBehaviour
    {

      // Use this for initialization
       void Start()
       {

        RetrieveData.Instance.GetDailyLevels();
        

       }
        // Update is called once per frame
        void Update()
        {
               
        }
    }


