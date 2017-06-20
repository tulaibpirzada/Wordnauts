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
    private int puzzleType;

	public List<string> Puzzle
	{
		get { return puzzle; }
	}
    public int PuzzleType
    {
        get { return puzzleType; }
        set { puzzleType = value; }
    }
	public int Hints
	{
		get { return hints; }
        set { hints=value; }
	}

	public int PrestigePoints
	{
		get { return prestigePoints; }
        set { prestigePoints=value; }
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

	public void Populate(DataSnapshot dataSnapShot,int pType, string levelPath)
	{
		string strPuzzleFromServer = ServerController.Instance.GetChildDataFromSnapshot(dataSnapShot, levelPath + "grid");
        puzzleType=pType;

		if (strPuzzleFromServer != null)
		{
			ServerController.Instance.ConvertPuzzletoGrid(strPuzzleFromServer);
			this.puzzle = ServerController.Instance.gamePuzzle;
			this.rows = ServerController.Instance.row;
			this.columns = ServerController.Instance.column;
			string clueString = ServerController.Instance.GetChildDataFromSnapshot (dataSnapShot, levelPath + "clue");
			this.clue = new List<string> (clueString.Split (','));
			this.hints = Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(dataSnapShot, levelPath + "pi"));
			this.prestigePoints = Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(dataSnapShot, levelPath + "prestige"));
			string solutionString = ServerController.Instance.GetChildDataFromSnapshot (dataSnapShot, levelPath + "solution");
			this.solution = new List<string> (solutionString.Split(new[] { ',', ' ' }));
            int countSolutionEntries = this.solution.Count;
            int countClueEntries = this.clue.Count;
            if (countSolutionEntries > 0 && countClueEntries == 1)
            {
                for (int i=0;i< countSolutionEntries-1; i++)
                {
                    this.clue.Add(clueString);
                }
            }
		}


	}
    public void UpdateReward()
    {
        PlayerModel.Instance.UpdateStarsAndHints(PrestigePoints, Hints);
    }
   
}
