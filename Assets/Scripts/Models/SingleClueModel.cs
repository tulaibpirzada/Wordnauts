using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SingleClueModel
{
    private List<string> puzzle;
    private int hints;
    private int prestigePoints;
    private int rows;
    private int columns;
    private string clue;
    private string solution ;

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

    public string Clue
    {
        get { return clue; }
    }

    public string Solution
    {
        get { return solution; }
    }

    public void Populate(string levelPath)
    {
        string strPuzzleFromServer = ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.singleClueSnapshot, levelPath + "grid");
        Debug.Log("Puzzle Pack count: " + DatabaseModel.Instance.singleClueSnapshot.ChildrenCount);

        if (strPuzzleFromServer != null)
        {
            ServerController.Instance.ConvertPuzzletoGrid(strPuzzleFromServer);
            this.puzzle = ServerController.Instance.gamePuzzle;
            this.rows = ServerController.Instance.row;
            this.columns = ServerController.Instance.column;
            this.clue = ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.singleClueSnapshot, levelPath + "clue");
            this.hints = Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.singleClueSnapshot, levelPath + "pi"));
            this.prestigePoints = Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.singleClueSnapshot, levelPath + "prestige"));
            this.solution = ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.singleClueSnapshot, levelPath + "solution");
        }

        
    }

}
