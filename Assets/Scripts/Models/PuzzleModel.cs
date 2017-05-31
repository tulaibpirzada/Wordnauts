using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class PuzzleModel {
	private List<string> puzzle;
	private int hints;
	private int prestigePoints;
	private int rows;
	private int columns;
	private List<string> clue = new List<string>();
	private List<string> solution = new List<string>();

	public List<string> Puzzle
	{
		get { return puzzle; }
	}

	public int Hints
	{
		get { return hints; }
	}

	public int PrestigePoints
	{
		get { return prestigePoints; }
	}

	public int Rows
	{
		get { return rows; }
	}

	public int Columns
	{
		get { return columns; }
	}

	public List<string> Clue
	{
		get { return clue; }
	}

	public List<string> Solution
	{
		get { return solution; }
	}

	public void Populate(DataSnapshot dataSnapShot, string levelPath)
	{
		string strPuzzleFromServer = ServerController.Instance.GetChildDataFromSnapshot(dataSnapShot, levelPath + "grid");

		if (strPuzzleFromServer != null)
		{
			ServerController.Instance.ConvertPuzzletoGrid(strPuzzleFromServer);
			this.puzzle = ServerController.Instance.gamePuzzle;
			this.rows = ServerController.Instance.row;
			this.columns = ServerController.Instance.column;
			this.clue.Add(ServerController.Instance.GetChildDataFromSnapshot(dataSnapShot, levelPath + "clue"));
			this.hints = Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(dataSnapShot, levelPath + "pi"));
			this.prestigePoints = Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(dataSnapShot, levelPath + "prestige"));
			this.solution.Add (ServerController.Instance.GetChildDataFromSnapshot (dataSnapShot, levelPath + "solution"));
		}


	}
}
