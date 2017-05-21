using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Firebase.Database;


class ServerController :Singleton<ServerController>
{
    public int rows;
    public int cols;
    public List<string> puzzle = new List<string>();

    public void PopulateDailyLevelData()
   {
        //Extract user details from user model
        int levelNo = 0;
        string levelPath = DatabaseModel.Instance.subLevelName + "/" + levelNo.ToString() + "/";
        string strPuzzleFromServer = GetChildDataFromSnapshot(DatabaseModel.Instance.dailyLevelSnapshot, levelPath + "grid");
        

        if (strPuzzleFromServer!=null)
        {
            ConvertPuzzletoGrid(strPuzzleFromServer);
            DailyLevelModel.Instance.clue=GetChildDataFromSnapshot(DatabaseModel.Instance.dailyLevelSnapshot, levelPath+"clue");
            DailyLevelModel.Instance.gems=Convert.ToInt32(GetChildDataFromSnapshot(DatabaseModel.Instance.dailyLevelSnapshot, levelPath+"pi"));
            DailyLevelModel.Instance.prestigePoints = Convert.ToInt32(GetChildDataFromSnapshot(DatabaseModel.Instance.dailyLevelSnapshot, levelPath+"prestige"));
            DailyLevelModel.Instance.hints = Convert.ToInt32(GetChildDataFromSnapshot(DatabaseModel.Instance.dailyLevelSnapshot, levelPath+"tickets"));
            DailyLevelModel.Instance.solution=GetChildDataFromSnapshot(DatabaseModel.Instance.dailyLevelSnapshot, levelPath+"solution");
        }
        else
        {
            Debug.Log("Unable to Fetch Puzzle");
        }
        

   }

    public void ConvertPuzzletoGrid(string rawPuzzle)
    {

        char[] array = rawPuzzle.ToCharArray();
        rows = 0;
        int c = 1;
        for (int i = 1; i < array.Length - 1; i++)
        {
            if (array[i] == '[')
            {

                c = 1;
            }
            else if (Char.IsLetter(array[i]) || array[i] == '_')
            {
                puzzle.Add(array[i].ToString());

            }
            else if (array[i] == ']')
            {
                rows++;
                cols = c;
            }
            else
            {
                c++;
            }
        }
    DailyLevelModel.Instance.rows = rows;
    DailyLevelModel.Instance.cols = cols;
    DailyLevelModel.Instance.puzzle = puzzle;

    }

    public string GetChildDataFromSnapshot(DataSnapshot snapshot, string childName)
    {
        string result;
        DataSnapshot child;
        if (snapshot.Exists && snapshot.HasChildren)
        {
            child = snapshot.Child(childName);
            // don't know what true or false do in current context
            object o = child.GetValue(false);
            if (o == null)
            {
                return null;
            }
            result = o.ToString();
            return result;
        }

        else
        {
            return null;
        }
    }
 
}

