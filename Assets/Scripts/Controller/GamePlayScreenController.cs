using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class GamePlayScreenController : Singleton<GamePlayScreenController> {

    GamePlayScreenReferences gamePlayScreenRef;
    private const int rowSize = 15;
    private List<LetterButtonReferences> letterButtonList;

    public void LoadScreen() {
        GameObject gamePlayScreenGameObject = ScreenTransitionManager.Instance.ShowScreen(GameConstants.Screens.GAME_PLAY_SCREEN);
		gamePlayScreenRef = gamePlayScreenGameObject.GetComponent<GamePlayScreenReferences>();
		gamePlayScreenRef.clueLabel.text = "Clue: " + DailyLevelModel.Instance.Clue;
		gamePlayScreenRef.wordBeingCreatedLabel.text = "";
        GenerateGrid();
        GenerateSolutionBox(DailyLevelModel.Instance.Solution);
    }

	public void SlideBackToMainMenu()
	{
		MainMenuController.Instance.ShowMainMenuScreen();
	}

	private void GenerateGrid()
	{
		var size = CalculateSize();
		gamePlayScreenRef.letterGrid.padding = new RectOffset((int)size.x, (int)size.x, (int)size.y, 0);
        gamePlayScreenRef.letterGrid.cellSize = new Vector2(size.z, size.z);
        letterButtonList = new List<LetterButtonReferences>();
		var index = 0;

        for (var i = 0; i < DailyLevelModel.Instance.Columns; i++)
		{
            for (var j = 0; j < DailyLevelModel.Instance.Rows; j++)
			{
				var letter = DailyLevelModel.Instance.Puzzle[index];
				CreateLetterButton(letter, i, j, index++, size.z);
			}
		}

		//EnableInteractionAfterTimeout();

	}

	private Vector3 CalculateSize()
	{
        var spacing = gamePlayScreenRef.letterGrid.spacing;
        var padding = gamePlayScreenRef.letterGrid.padding;
        var letterGridRectTransform = gamePlayScreenRef.letterGrid.GetComponent<RectTransform>();

		var numberOfRows = DailyLevelModel.Instance.Rows;
		var numberOfColumns = DailyLevelModel.Instance.Columns;
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
		//letterButton.IsBlock = letter == '_';
		//letterButton.LetterSelectedSignal = LetterSelectedSignal;
		//letterButton.LetterDeselectedSignal = LetterDeselectedSignal;

        letterButtonGameObject.transform.SetParent(gamePlayScreenRef.letterGrid.transform);
        letterButtonList.Add(letterButton);
		//view.GetLetterGrid.AddLetterButton(letterButton);

		//_letterButtons[row + "," + column] = letterButtonGameObject.GetComponent<LetterButton>();
	}

    private void GenerateSolutionBox(List<string> solutionList)
	{
		//var solutionRowPrefab = Resources.Load("SolutionRow");
		//var letterBoxPrefab = Resources.Load("LetterBox");
		//var emptyLetterBoxPrefab = Resources.Load("EmptyLetterBox");

		//var words = solution.Split(solutionSplit);

		var numberOfLettersUsedInRow = 0;
		GameObject solutionRow = null;

        foreach (string word in solutionList)
		{

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
			for (var i = 0; i < wordLength; i++)
			{
				var letterBox = (GameObject)UnityEngine.Object.Instantiate(gamePlayScreenRef.solutionLetterBox);
				letterBox.transform.SetParent(solutionRow.transform);
				letterBox.transform.localScale = new Vector3(1, 1, 1);

				//letterQueue.Enqueue(letterBox.GetComponent<LetterBox>());
				//letterList.Add(letterBox.GetComponent<LetterBox>());
			}

			//_wordToLettersMap.Add(new KeyValuePair<string, Queue<LetterBox>>(word, letterQueue));
			//_letterBoxes.Add(new KeyValuePair<string, List<LetterBox>>(word, letterList));
			numberOfLettersUsedInRow += spaceNeededForWord;
		}
	}

    public void CreateWord(string character) {
        gamePlayScreenRef.wordBeingCreatedLabel.text += character;
    }

    public void CheckIfWordCreatedIsCorrectSolution() {
        foreach (string solutionString in DailyLevelModel.Instance.Solution) {
            if (gamePlayScreenRef.wordBeingCreatedLabel.text == solutionString) {
				foreach (LetterButtonReferences letterButton in letterButtonList)
				{
                    letterButton.CorrectlySelectLetter();
				}
                return;
            }
		}

        //Deselect All Letters
        foreach (LetterButtonReferences letterButton in letterButtonList) {
            letterButton.DeselectLetter();
        }
        gamePlayScreenRef.wordBeingCreatedLabel.text = "";

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
