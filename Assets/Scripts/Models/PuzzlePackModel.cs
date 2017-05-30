﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class PuzzlePackModel
{

    
    private int requiredPointsToUnlock;
    private int totalLevels;
	public List<SingleClueModel> levelsList = new List<SingleClueModel>();


    public int RequiredPointsToUnlock
    {
        get { return requiredPointsToUnlock; }
        set { requiredPointsToUnlock = value; }
    }

    public int TotalLevels
    {
        get { return totalLevels; }
        set { totalLevels = value; }
    }

    public void Populate(int packNo)
    {
        string levelPath;
        string packPath = packNo.ToString() + "/";
        requiredPointsToUnlock = Convert.ToInt32(ServerController.Instance.GetChildDataFromSnapshot(DatabaseModel.Instance.singleClueSnapshot, packPath + "PrestigeToUnlock"));
        
        string allLevelInPackPath = packPath + DatabaseModel.Instance.subLevelName + "/";
        totalLevels = Convert.ToInt32(ServerController.Instance.getCountofChildren(DatabaseModel.Instance.singleClueSnapshot, allLevelInPackPath));
        for (int level = 0; level < totalLevels; level++)
        {
            levelPath = packPath + DatabaseModel.Instance.subLevelName + "/" + level.ToString() + "/";
			PuzzleModel puzzleModel = new PuzzleModel();
			puzzleModel.Populate(levelPath);
			levelsList.Add(puzzleModel);
        }
    }
}

