using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MultiplePackModel: Singleton<MultiplePackModel>
{
    private int totalPacks;
	public List<PuzzlePackModel> packsList = new List<PuzzlePackModel>();
    public int TotalPacks
    {
        get { return totalPacks; }
        set { totalPacks = value; }
    }
    public void Populate()
    {
        TotalPacks =Convert.ToInt32(DatabaseModel.Instance.singleClueSnapshot.ChildrenCount);
        int packNo = PlayerModel.Instance.singleClue.PackNo;
		for (int index = 0; index <=packNo+1; index++)
        {
            PuzzlePackModel pack = new PuzzlePackModel();
			pack.Populate(index);
			packsList.Add(pack);
        }

    }
 }

