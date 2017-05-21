using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class dailyLevelDic
{
   public  bool isAvailable;
   public  string date;
   public int LevelNo;

    public dailyLevelDic()
    {
        isAvailable = true;
        date = DateTime.Today.ToString();
        LevelNo = 0;
    }
}

