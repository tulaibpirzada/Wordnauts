using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MultiClueModel
{
    private List<string> puzzle;
    private int hints;
    private int prestigePoints;
    private int rows;
    private int columns;
    private List<string> clues=new List<string>();
    private List<string> solutions = new List<string>();

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
        get { return clues; }
    }

    public List<string> Solution
    {
        get { return solutions; }
    }

    public void Populate(string levelPath)
    {
        
        string strPuzzleFromServer = ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.multiClueSnapshot, levelPath + "grid");


        if (strPuzzleFromServer != null)
        {
            ServerController.Instance.ConvertPuzzletoGrid(strPuzzleFromServer);
            puzzle = ServerController.Instance.gamePuzzle;
            rows = ServerController.Instance.row;
            columns = ServerController.Instance.column;
            string allClues = ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.multiClueSnapshot, levelPath + "clue");
            clues = Utils.SplitAndSaveStrings(allClues, ',');
            hints = Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.multiClueSnapshot, levelPath + "pi"));
            prestigePoints = Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.multiClueSnapshot, levelPath + "prestige"));
            string allSolutions = ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.multiClueSnapshot, levelPath + "solution");
            solutions = Utils.SplitAndSaveStrings(allSolutions, ',');

        }
        else
        {
            // Debug.Log("Unable to Fetch Puzzle");
        }
    }
}

