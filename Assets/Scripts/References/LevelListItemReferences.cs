using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelListItemReferences : MonoBehaviour {

	public Text titleLabel;
	public GameObject newIcon;
	public GameObject lockIcon;
	public GameObject arrowIcon;
	public GameObject tickIcon;
	public Button button;
	public PuzzleModel puzzleModel;
	public enum LevelListType {
		SingleClueLevelList,
		MultiClueLevelList
	}
	public LevelListType levelListType;
}
