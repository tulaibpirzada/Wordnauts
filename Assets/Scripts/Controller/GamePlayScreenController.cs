﻿﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;


public class GamePlayScreenController : Singleton<GamePlayScreenController> {

    GamePlayScreenReferences gamePlayScreenRef;
    private const int rowSize = 15;
	private Dictionary<string, LetterButtonReferences> letterButtonDictionary;
    private List<LetterButtonReferences> letterButtonGridList;
	private Dictionary<string, Vector3> letterButtonPositions;
	private List<GameObject> solutionRowList;
    private Dictionary<string, List<GameObject>> solutionLetterBoxDictionary;
    private List<GameObject> wordCreatedLetterButtonList;
	private PuzzleModel puzzleModel;
    private int currentSolutionIndex;
    public bool isGamePlayScreenShowingUp = false;

    public void LoadScreen(PuzzleModel puzzleModel) {
		this.puzzleModel = puzzleModel;
        isGamePlayScreenShowingUp = true;
        GameObject gamePlayScreenGameObject = ScreenTransitionManager.Instance.ShowScreen(GameConstants.Screens.GAME_PLAY_SCREEN);
		gamePlayScreenRef = gamePlayScreenGameObject.GetComponent<GamePlayScreenReferences>();
		gamePlayScreenRef.clueLabel.text = "Clue: " + puzzleModel.Clue[0];
		gamePlayScreenRef.wordBeingCreatedLabel.text = "";
        gamePlayScreenRef.hintsCount.text="Hints ("+PlayerModel.Instance.hints.ToString()+ ")";
        GenerateGrid();
		GenerateSolutionBox(puzzleModel.Solution);
        wordCreatedLetterButtonList = new List<GameObject>();
        if (puzzleModel.Solution.Count > 0) {
            currentSolutionIndex = 0;
        }

    }

	public void SlideBackToMainMenu()
	{
		ClearupGamePlayScreen ();
		MainMenuController.Instance.ShowMainMenuScreen();
	}

	private void GenerateGrid()
	{
		var size = CalculateSize();
		gamePlayScreenRef.letterGrid.padding = new RectOffset((int)size.x, (int)size.x, (int)size.y, 0);
        gamePlayScreenRef.letterGrid.cellSize = new Vector2(size.z, size.z);
		letterButtonDictionary = new Dictionary<string, LetterButtonReferences> ();
        letterButtonGridList = new List<LetterButtonReferences>();
		var index = 0;

		for (var i = 0; i < puzzleModel.Columns; i++)
		{
			for (var j = 0; j < puzzleModel.Rows; j++)
			{
				var letter = puzzleModel.Puzzle[index];
				CreateLetterButton(letter, i, j, index++, size.z);
			}
		}

		EnableInteractionAfterTimeout();

	}

	private void EnableInteractionAfterTimeout()
	{
		letterButtonPositions = new Dictionary<string, Vector3> ();
		var f = 0f;
		DOTween.To(() => f, x => f = x, 0.0f, 0.5f).OnComplete(() =>
			{
				foreach (KeyValuePair<string, LetterButtonReferences> letterButtonPair in letterButtonDictionary)
				{
					letterButtonPositions[letterButtonPair.Key] = letterButtonPair.Value.gameObject.transform.position;
				}
			});
	}

	private Vector3 CalculateSize()
	{
        var spacing = gamePlayScreenRef.letterGrid.spacing;
        var padding = gamePlayScreenRef.letterGrid.padding;
        var letterGridRectTransform = gamePlayScreenRef.letterGrid.GetComponent<RectTransform>();

		var numberOfRows = puzzleModel.Rows;
		var numberOfColumns = puzzleModel.Columns;
		var horizontalSpacing = (numberOfColumns - 1) * spacing.x;
		var verticalSpacing = (numberOfRows - 1) * spacing.y;
		var horizontalPadding = padding.left + padding.right;
		var verticalPadding = padding.top + padding.bottom;
		var width = letterGridRectTransform.rect.width - horizontalSpacing - horizontalPadding;
		var height = letterGridRectTransform.rect.height - verticalSpacing - verticalPadding;
		float minOfWAndH = Math.Min (height / numberOfRows, width / numberOfColumns);
		var size = Math.Min(minOfWAndH, 500);

		var leftOverWidth = width - size * numberOfColumns;
		var leftOverHeight = height - size * numberOfRows;

		horizontalPadding = Math.Max((int)(leftOverWidth / 2), padding.left);
		verticalPadding = Math.Max((int)(leftOverHeight / 2), padding.top);

		return new Vector3(horizontalPadding, verticalPadding, size);
	}

	private void CreateLetterButton(string letter, int row, int column, int index, float size)
	{
        var letterButtonGameObject = (GameObject)UnityEngine.Object.Instantiate(gamePlayScreenRef.letterButton);
        var letterButton = letterButtonGameObject.GetComponent<LetterButtonReferences>();

		letterButton.Letter = letter;
		letterButton.Column = column;
		letterButton.Index = index;
		letterButton.Row = row;
		letterButton.Size = size;
        letterButton.IsMoved = false;
		//letterButton.IsBlock = letter == '_';
		//letterButton.LetterSelectedSignal = LetterSelectedSignal;
		//letterButton.LetterDeselectedSignal = LetterDeselectedSignal;

        letterButtonGameObject.transform.SetParent(gamePlayScreenRef.letterGrid.transform);
		letterButtonDictionary[letterButton.Row + "," + letterButton.Column] = letterButton;
        letterButtonGridList.Add(letterButton);
		//view.GetLetterGrid.AddLetterButton(letterButton);

		//_letterButtons[row + "," + column] = letterButtonGameObject.GetComponent<LetterButton>();
	}

    private void GenerateSolutionBox(List<string> solutionList)
	{
		solutionRowList = new List<GameObject>();
        solutionLetterBoxDictionary = new Dictionary<string, List<GameObject>>();
		var numberOfLettersUsedInRow = 0;
		GameObject solutionRow = null;

        foreach (string word in solutionList)
		{
			Debug.Log ("Solution:" + word);
			//if (IsWordAlreadyAdded(word)) continue;

            int wordLength = word.Length;
			int spaceNeededForWord;
			var availableSpace = rowSize - numberOfLettersUsedInRow;

			if (numberOfLettersUsedInRow == 0)
			{
				spaceNeededForWord = wordLength;
			}
			else
			{
				spaceNeededForWord = wordLength + 1;
			}

			if (numberOfLettersUsedInRow == 0 || spaceNeededForWord > availableSpace)
			{
				numberOfLettersUsedInRow = 0;
				solutionRow = (GameObject)UnityEngine.Object.Instantiate(gamePlayScreenRef.solutionRow);
                solutionRow.transform.SetParent(gamePlayScreenRef.solutionBox.transform);
				solutionRow.transform.localScale = new Vector3(1, 1, 1);
				solutionRowList.Add (solutionRow);
			}

			if (solutionRow == null)
			{
                throw new System.Exception("Solution row is not created");
			}

			if (numberOfLettersUsedInRow != 0)
			{
				var emptyLetterBox = (GameObject)UnityEngine.Object.Instantiate(gamePlayScreenRef.solutionEmptyLetterBox);
				emptyLetterBox.transform.SetParent(solutionRow.transform);
			}


            //var letterQueue = new Queue<LetterBox>(wordLength);
            //var letterList = new List<LetterBox>(wordLength);
            List<GameObject> solutionLetterBoxList = new List<GameObject>();
			for (var i = 0; i < wordLength; i++)
			{
				var letterBox = (GameObject)UnityEngine.Object.Instantiate(gamePlayScreenRef.solutionLetterBox);
				letterBox.transform.SetParent(solutionRow.transform);
				letterBox.transform.localScale = new Vector3(1, 1, 1);
                solutionLetterBoxList.Add(letterBox);
				LetterBoxReferences letterBoxRef = letterBox.GetComponent<LetterBoxReferences> ();
				letterBoxRef.letterLabel.gameObject.SetActive (false);
				Char character = word.ToCharArray () [i];
				letterBoxRef.letterLabel.text = character.ToString ();
				//letterQueue.Enqueue(letterBox.GetComponent<LetterBox>());
				//letterList.Add(letterBox.GetComponent<LetterBox>());
			}
            solutionLetterBoxDictionary.Add(word, solutionLetterBoxList);

			//_wordToLettersMap.Add(new KeyValuePair<string, Queue<LetterBox>>(word, letterQueue));
			//_letterBoxes.Add(new KeyValuePair<string, List<LetterBox>>(word, letterList));
			numberOfLettersUsedInRow += spaceNeededForWord;
		}
	}

    public void CreateWord(string character, GameObject letterButton) {
        gamePlayScreenRef.wordBeingCreatedLabel.text += character;
        wordCreatedLetterButtonList.Add(letterButton);
    }

	public void CheckIfWordCreatedIsCorrectSolution() {
        string solutionString = puzzleModel.Solution[currentSolutionIndex];
        if (gamePlayScreenRef.wordBeingCreatedLabel.text == solutionString) {
            foreach (GameObject letterButtonGameObject in wordCreatedLetterButtonList)
			{
                LetterButtonReferences letterButton = letterButtonGameObject.GetComponent<LetterButtonReferences>();
				letterButton.CorrectlySelectLetter();
			}
            
            MoveLetterButtonToSolutionRow(solutionString);
			return;
        }


        Sequence deselectTween = DOTween.Sequence(); ;
        for (int i = 0; i < wordCreatedLetterButtonList.Count; i++)
        {
            Debug.Log(wordCreatedLetterButtonList.Count);
            deselectTween.Insert(0f, wordCreatedLetterButtonList[i].transform.DOPunchRotation(new Vector3(0, 0, 10f), 0.4f));           
        }
        deselectTween.Play();

		//Deselect All Letters
		foreach (GameObject letterButtonGameObject in wordCreatedLetterButtonList)
		{
			LetterButtonReferences letterButton = letterButtonGameObject.GetComponent<LetterButtonReferences>();
			letterButton.DeselectLetter();
		}
        wordCreatedLetterButtonList.Clear();
        gamePlayScreenRef.wordBeingCreatedLabel.text = "";

    }

	private IEnumerator ResetScreenAndLoadLevelEnd() {
		yield return new WaitForSeconds (1);
		ClearupGamePlayScreen ();
		LevelEndScreenController.Instance.LoadScreen (puzzleModel);
		yield return null;
	}

    private void MoveLetterButtonToSolutionRow(string solutionString) {
        List<GameObject> solutionBoxes = solutionLetterBoxDictionary.GetValue(solutionString);
        Sequence sequence = DOTween.Sequence();
        for (int i = 0; i < solutionBoxes.Count; i++) {
            if (i == 0) {
                sequence.Append(wordCreatedLetterButtonList[i].transform.DOMove(solutionBoxes[i].transform.position, 1.0f));
            } else {
                sequence.Join(wordCreatedLetterButtonList[i].transform.DOMove(solutionBoxes[i].transform.position, 1.0f));
            }
			sequence.Join (wordCreatedLetterButtonList [i].transform.DOScale (Vector3.zero, 1.0f));
        }
		sequence.AppendCallback(()=> SetSolutionWord(solutionBoxes));
    }

	private void SetSolutionWord(List<GameObject> solutionBoxes) {
		for (int i = 0; i < solutionBoxes.Count; i++) {
			Debug.Log ("Hello: "+ i);
			LetterBoxReferences letterBox = solutionBoxes [i].GetComponent<LetterBoxReferences> ();
			letterBox.letterLabel.gameObject.SetActive (true);
            LetterButtonReferences letterButton = wordCreatedLetterButtonList[i].GetComponent<LetterButtonReferences>();
            letterButton.IsMoved = true;
		}
        gamePlayScreenRef.wordBeingCreatedLabel.text = "";
        wordCreatedLetterButtonList.Clear();
        if (currentSolutionIndex + 1 < puzzleModel.Solution.Count) {
            ReconstructGrid();
        } else {
            StartCoroutine(ResetScreenAndLoadLevelEnd());
		}
	}

	private void ClearupGamePlayScreen() {
		isGamePlayScreenShowingUp = false;
        foreach (LetterButtonReferences letterButton in letterButtonGridList) {
			Destroy(letterButton.gameObject); 
		}
		letterButtonDictionary.Clear();
		foreach (GameObject solutionRow in solutionRowList) {
			Destroy(solutionRow); 
		}
		solutionRowList.Clear();
	}

	private void ReconstructGrid() {
        Dictionary<string, LetterButtonReferences> updatedLetterButtonDictionary = new Dictionary<string, LetterButtonReferences>();
		Sequence dropSequence = DOTween.Sequence();
		for (int i = puzzleModel.Rows - 1; i >= 0; i--)
		{
			for (int j = 0; j < puzzleModel.Columns; j++)
			{
                LetterButtonReferences letterButton = letterButtonDictionary[i + "," + j];
				if (letterButton != null) {
					if (!letterButton.IsMoved) {
						updatedLetterButtonDictionary [i + "," + j] = letterButton;
						continue;
					} else {
						bool isLetterButtonAvailableForPosition = false;
						for (int upperRow = i - 1; upperRow >= 0; upperRow--) {
							LetterButtonReferences upperRowLetterButton = letterButtonDictionary [upperRow + "," + j];
							if (upperRowLetterButton != null) {
								if (upperRowLetterButton.IsMoved) {
									continue;
								} else {
									Vector3 usedButtonPosition = letterButtonPositions [i + "," + j];
									upperRowLetterButton.IsMoved = true;
									updatedLetterButtonDictionary [i + "," + j] = upperRowLetterButton;
//									upperRowLetterButton.transform.position = usedButtonPosition;
									isLetterButtonAvailableForPosition = true;
									dropSequence.Append (upperRowLetterButton.transform.DOMove (usedButtonPosition, 0.3f));
									break;
								}
							} else {
								updatedLetterButtonDictionary [i + "," + j] = null;
								break;
							}
						}
						if (!isLetterButtonAvailableForPosition) {
							updatedLetterButtonDictionary [i + "," + j] = null;
						}
//						if (i - 1 < 0) {
//							updatedLetterButtonDictionary [i + "," + j] = null;
//						}
					}
				} else {
					updatedLetterButtonDictionary [i + "," + j] = null;
					continue;
				}
			}
		}
//		ResetLetterButtonDictionaryAndPositionList (updatedLetterButtonDictionary);
        dropSequence.AppendCallback(()=>ResetLetterButtonDictionaryAndPositionList(updatedLetterButtonDictionary));
	}

    private void ResetLetterButtonDictionaryAndPositionList(Dictionary<string, LetterButtonReferences> updatedLetterButtonDictionary) {
        letterButtonDictionary.Clear();
        foreach (KeyValuePair<string, LetterButtonReferences> letterButtonPair in updatedLetterButtonDictionary) {
            letterButtonDictionary.Add(letterButtonPair.Key, letterButtonPair.Value);
        }
		letterButtonPositions.Clear ();
		foreach (KeyValuePair<string, LetterButtonReferences> letterButtonPair in letterButtonDictionary)
		{
			if (letterButtonPair.Value != null) {
				letterButtonPositions [letterButtonPair.Key] = letterButtonPair.Value.gameObject.transform.position;
			} else {
				letterButtonPositions [letterButtonPair.Key] = Vector3.zero;
			}
		}
		foreach (KeyValuePair<string, LetterButtonReferences> letterButtonPair in updatedLetterButtonDictionary) {
			if (letterButtonPair.Value != null) {
				letterButtonPair.Value.IsMoved = false;
			}
		}
        currentSolutionIndex++;

    }

	//private bool IsWordAlreadyAdded(string word)
	//{
	//	foreach (var keyValuePair in _wordToLettersMap)
	//	{
	//		if (keyValuePair.Key == word)
	//		{
	//			return true;
	//		}
	//	}

	//	return false;
	//}

}
