using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Database;
using UnityEngine;
class DailyLevelModel : Singleton<DailyLevelModel>
{
    private List<string> puzzle;
    private int hints;
    private int prestigePoints;
    private int totalLevels;
	private int rows;
	private int columns;
    private string clue;
    private List<string> solution=new List<string>();


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

	public int TotalLevels
	{
		get { return totalLevels; }
	}

	public int Rows
	{
		get { return rows; }
	}

	public int Columns
	{
		get { return columns; }
	}

	public string Clue
	{
		get { return clue; }
	}

	public List<string> Solution
	{
		get { return solution; }
	}

    public void Populate()
	{
        /*  puzzle = Utils.GetList("puzzle", dataDictionary);
          hints = Utils.GetInt("hints", dataDictionary);
          prestigePoints = Utils.GetInt("prestige", dataDictionary);
          rows = Utils.GetInt("rows", dataDictionary);
          columns = Utils.GetInt("columns", dataDictionary);
          clue = Utils.GetString("clue", dataDictionary);
          string solutionString = Utils.GetString("solution", dataDictionary);
          solution = new List<string>();
          solution.Add(solutionString);*/
        //Extract user details from user model
        int levelNo = PlayerModel.Instance.dailyLevel.LevelNo;
        string levelPath = DatabaseModel.Instance.subLevelName + "/" + levelNo.ToString() + "/";
        string strPuzzleFromServer = ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.dailyLevelSnapshot, levelPath + "grid");


        if (strPuzzleFromServer != null)
        {
            ServerController.Instance.ConvertPuzzletoGrid(strPuzzleFromServer);
            puzzle = ServerController.Instance.gamePuzzle;
            rows= ServerController.Instance.row;
            columns= ServerController.Instance.column;
            clue = ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.dailyLevelSnapshot, levelPath + "clue");
            hints =Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.dailyLevelSnapshot, levelPath + "pi"));
            prestigePoints=Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.dailyLevelSnapshot, levelPath + "prestige"));
            solution.Add(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.dailyLevelSnapshot, levelPath + "solution"));


        }
        else
        {
            Debug.Log("Unable to Fetch Puzzle");
        }

    }
}
