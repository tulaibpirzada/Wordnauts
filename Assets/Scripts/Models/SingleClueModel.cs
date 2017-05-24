using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class SingleClueModel :Singleton<SingleClueModel>
{
    private List<string> puzzle;
    private int hints;
    private int prestigePoints;
    private int totalLevels;
    private int totalPacks;
    private int rows;
    private int columns;
    private string clue;
    private string solution ;
    private int requiredPointsToUnlock;

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

    public string Solution
    {
        get { return solution; }
    }

    public void Populate()
    {
        int packNo = PlayerModel.Instance.singleClue.PackNo;
        int levelNo= PlayerModel.Instance.singleClue.LevelNo;
        string packPath = packNo.ToString() + "/";
        string levelPath=packPath+ DatabaseModel.Instance.subLevelName + "/" + levelNo.ToString() + "/";
        string strPuzzleFromServer = ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.singleClueSnapshot, levelPath + "grid");


        if (strPuzzleFromServer != null)
        {
            ServerController.Instance.ConvertPuzzletoGrid(strPuzzleFromServer);
            puzzle = ServerController.Instance.gamePuzzle;
            rows = ServerController.Instance.row;
            columns = ServerController.Instance.column;
            requiredPointsToUnlock = Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.singleClueSnapshot, packPath + "PrestigeToUnlock"));
            clue = ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.singleClueSnapshot, levelPath + "clue");
            hints = Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.singleClueSnapshot, levelPath + "pi"));
            prestigePoints = Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.singleClueSnapshot, levelPath + "prestige"));
            solution = ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.singleClueSnapshot, levelPath + "solution");
        }

        
    }

}
