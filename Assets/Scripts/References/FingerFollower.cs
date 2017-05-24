﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerFollower : MonoBehaviour {

    private bool shouldGameObjectBeMoved;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = gameObject.transform.position;
    }
    void Update()
	{
		if ((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown (0))) {

			Debug.Log ("touch began");
            gameObject.GetComponent<Collider2D>().enabled = true;
			Vector3 worldPoint = Vector3.zero;
#if UNITY_EDITOR
			worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			//for touch device
#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
            worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
#endif
			Debug.Log ("World Point: " + worldPoint);
            gameObject.transform.position = new Vector3(worldPoint.x, worldPoint.y, 0);
			shouldGameObjectBeMoved = true;

		}
		if (shouldGameObjectBeMoved && ((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) ||
		    (Input.GetAxisRaw ("Mouse X") != 0 || Input.GetAxisRaw ("Mouse Y") != 0))) {
			//Debug.Log ("touch moved");
			Vector3 worldPoint = Vector3.zero;
#if UNITY_EDITOR
			worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			//for touch device
#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
            worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
#endif
			gameObject.transform.position = new Vector3(worldPoint.x, worldPoint.y, 0);
		}

		if (shouldGameObjectBeMoved && ((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp (0)))) {
			Debug.Log ("touch ended");
			Vector3 worldPoint = Vector3.zero;
#if UNITY_EDITOR
			worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			//for touch device
#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
            worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
#endif
			Debug.Log ("World Point: " + worldPoint);
            shouldGameObjectBeMoved = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.transform.position = initialPosition;
            GamePlayScreenController.Instance.CheckIfWordCreatedIsCorrectSolution();
		}
	}
}

