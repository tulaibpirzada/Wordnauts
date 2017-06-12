using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScreenReferences : MonoBehaviour {
    public GridLayoutGroup letterGrid;
    public VerticalLayoutGroup solutionBox;
    public Object letterButton;
    public Object solutionRow;
    public Object solutionLetterBox;
    public Object solutionEmptyLetterBox;
    public GameObject hintsButton;
	public Text wordBeingCreatedLabel;
	public Text clueLabel;
    public Text hintsCount;
    public Object hintedLetter;
}
