using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    class DailyLevelModel : Singleton<DailyLevelModel>
    {
        public List<string> puzzle;
        public int gems;
        public int hints;
        public int prestigePoints;
        public string clue;
        public int totalLevels;
        public string solution;
        public int rows;
        public int cols;

    }

