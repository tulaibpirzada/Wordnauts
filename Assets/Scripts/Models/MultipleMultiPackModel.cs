using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class MultipleMultiPackModel : Singleton<MultipleMultiPackModel>
{
    private int totalLevels;
	public List<PuzzleModel> puzzleModelList= new List<PuzzleModel>();
    public int TotalLevels
    {
        get { return totalLevels; }
    }

    public void Populate()
    {
        int levelNo = PlayerModel.Instance.multiClue.LevelNo;
        string levelPath;
        string path= DatabaseModel.Instance.subLevelName + "/";
        totalLevels = Convert.ToInt32(ServerController.Instance.GetCountofChildren(DatabaseModel.Instance.multiClueSnapshot, path));
		for (int levels=0; levels < totalLevels; levels++)
        {
			PuzzleModel puzzleModel = new PuzzleModel();
			levelPath = path + levels.ToString() + "/";
			puzzleModel.Populate(DatabaseModel.Instance.multiClueSnapshot,3, levelPath);
			puzzleModelList.Add(puzzleModel);
        }
    }
}

