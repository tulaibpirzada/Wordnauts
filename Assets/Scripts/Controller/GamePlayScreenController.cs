using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayScreenController : Singleton<GamePlayScreenController> {

    GamePlayScreenReferences gamePlayScreenRef;

    public void LoadScreen() {
        GameObject gamePlayScreenGameObject = ScreenTransitionManager.Instance.ShowScreen(GameConstants.Screens.GAME_PLAY_SCREEN);
		gamePlayScreenRef = gamePlayScreenGameObject.GetComponent<GamePlayScreenReferences>();
        GenerateGrid();
    }

	public void SlideBackToMainMenu()
	{
		MainMenuController.Instance.ShowMainMenuScreen();
	}

	private void GenerateGrid()
	{
		var size = CalculateSize();

        gamePlayScreenRef.letterGrid.padding = new RectOffset((int)size.y, (int)size.x, 0, (int)size.x);
        gamePlayScreenRef.letterGrid.cellSize = new Vector2(size.z, size.z);

		var index = 1;

		for (var i = 0; i < 3; i++)
		{
			for (var j = 0; j < 4; j++)
			{
				//var letter = _letterMatrix[i, j];
				CreateLetterButton('A', i, j, index++, size.z);
			}
		}

		//EnableInteractionAfterTimeout();

	}

	private Vector3 CalculateSize()
	{
        var spacing = gamePlayScreenRef.letterGrid.spacing;
        var padding = gamePlayScreenRef.letterGrid.padding;
        var letterGridRectTransform = gamePlayScreenRef.letterGrid.GetComponent<RectTransform>();

		var numberOfRows = 3;
		var numberOfColumns = 4;
		var horizontalSpacing = (numberOfColumns - 1) * spacing.x;
		var verticalSpacing = (numberOfRows - 1) * spacing.y;
		var horizontalPadding = padding.left + padding.right;
		var verticalPadding = padding.top + padding.bottom;
		var width = letterGridRectTransform.rect.width - horizontalSpacing - horizontalPadding;
		var height = letterGridRectTransform.rect.height - verticalSpacing - verticalPadding;
        var size = Mathf.Min(Mathf.Min(height / numberOfRows, width / numberOfColumns), 500);

		var leftOverWidth = width - size * numberOfColumns;
		var leftOverHeight = height - size * numberOfRows;

		horizontalPadding = Mathf.Max((int)(leftOverWidth / 2), padding.left);
		verticalPadding = Mathf.Max((int)(leftOverHeight / 2), padding.top);

		return new Vector3(horizontalPadding, verticalPadding, size);
	}

	private void CreateLetterButton(char letter, int row, int column, int index, float size)
	{
        var letterButtonGameObject = (GameObject)Object.Instantiate(gamePlayScreenRef.letterButton);
        var letterButton = letterButtonGameObject.GetComponent<LetterButtonReferences>();

		//letterButton.Letter = letter;
		//letterButton.Column = column;
		//letterButton.Index = index;
		//letterButton.Row = row;
		//letterButton.Size = size;
		//letterButton.IsBlock = letter == '_';
		//letterButton.LetterSelectedSignal = LetterSelectedSignal;
		//letterButton.LetterDeselectedSignal = LetterDeselectedSignal;

        letterButtonGameObject.transform.SetParent(gamePlayScreenRef.letterGrid.transform);
		//view.GetLetterGrid.AddLetterButton(letterButton);

		//_letterButtons[row + "," + column] = letterButtonGameObject.GetComponent<LetterButton>();
	}
}
