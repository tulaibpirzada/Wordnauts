using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class MultipleMultiPackModel : Singleton<MultipleMultiPackModel>
{
    private int totalLevels;
    public Dictionary<int,object> MultiLevelsModel= new Dictionary<int,object>();
    public int TotalLevels
    {
        get { return totalLevels; }
    }

    public void Populate()
    {
        int levelNo = PlayerModel.Instance.multiClue.LevelNo;
        string levelPath;
        string path= DatabaseModel.Instance.subLevelName + "/";
        totalLevels = Convert.ToInt32(ServerController.Instance.getCountofChildren(DatabaseModel.Instance.multiClueSnapshot, path));
        for (int levels=0; levels<levelNo; levels++)
        {
            MultiClueModel mc = new MultiClueModel();
            levelPath = path+ levelNo.ToString() + "/";
            mc.Populate(levelPath);
            MultiLevelsModel.Add(levels, mc);
        }
    }
}

