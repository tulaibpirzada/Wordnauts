using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Database;

class DailyLevelModel : Singleton<DailyLevelModel>
{
    private List<string> puzzle;
    private int hints;
    private int prestigePoints;
    private int totalLevels;
	private int rows;
	private int columns;
    private string clue;
    private string solution;


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

    public void Populate(Dictionary<string, object> dataDictionary)
	{
        puzzle = Utils.GetList("puzzle", dataDictionary);
        hints = Utils.GetInt("hints", dataDictionary);
		prestigePoints = Utils.GetInt("prestige", dataDictionary);
		rows = Utils.GetInt("rows", dataDictionary);
		columns = Utils.GetInt("columns", dataDictionary);
        clue = Utils.GetString("clue", dataDictionary);
        solution = Utils.GetString("solution", dataDictionary);
	}
}
