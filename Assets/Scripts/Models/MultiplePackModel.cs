using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MultiplePackModel:Singleton<MultiplePackModel>
{
    private int totalPacks;
    public Dictionary<int, object> packsDictionary = new Dictionary<int, object>();
    public int TotalPacks
    {
        get { return totalPacks; }
        set { totalPacks = value; }
    }
    public void Populate()
    {
        TotalPacks =Convert.ToInt32(DatabaseModel.Instance.singleClueSnapshot.ChildrenCount);
        int packNo = PlayerModel.Instance.singleClue.PackNo;
        for (int pack = 0; pack <=packNo; pack++)
        {
            PuzzlePackModel pp = new PuzzlePackModel();
            pp.Populate(pack);
            packsDictionary.Add(packNo, pp);
        }

    }
 }

