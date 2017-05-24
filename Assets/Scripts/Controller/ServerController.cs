﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Firebase.Database;


class ServerController : Singleton<ServerController>
{
   // private Dictionary<string, object> dailyLevelDictionary = new Dictionary<string, object>();
    public List<string> gamePuzzle;
    public int row;
    public int column;

    /*public void PopulateDailyLevelData()
    {
        //Extract user details from user model
        int levelNo = PlayerModel.Instance.dailyLevel.LevelNo;
        string levelPath = DatabaseModel.Instance.subLevelName + "/" + levelNo.ToString() + "/";
        string strPuzzleFromServer = GetChildDataFromSnapshot(DatabaseModel.Instance.dailyLevelSnapshot, levelPath + "grid");


        if (strPuzzleFromServer != null)
        {
            ConvertPuzzletoGrid(strPuzzleFromServer);
            dailyLevelDictionary.Add("clue", GetChildDataFromSnapshot(DatabaseModel.Instance.dailyLevelSnapshot, levelPath + "clue"));
            dailyLevelDictionary.Add("prestige", GetChildDataFromSnapshot(DatabaseModel.Instance.dailyLevelSnapshot, levelPath + "prestige"));
            dailyLevelDictionary.Add("hints", GetChildDataFromSnapshot(DatabaseModel.Instance.dailyLevelSnapshot, levelPath + "pi"));
            dailyLevelDictionary.Add("solution", GetChildDataFromSnapshot(DatabaseModel.Instance.dailyLevelSnapshot, levelPath + "solution"));
            DailyLevelModel.Instance.Populate(dailyLevelDictionary);
        }
        else
        {
            Debug.Log("Unable to Fetch Puzzle");
        }
    }*/

    public void ConvertPuzzletoGrid(string rawPuzzle)
    {

        int rows = 0;
        int cols;
        List<string> puzzle = new List<string>();
        char[] array = rawPuzzle.ToCharArray();
        int c = 1;
        cols = c;
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
        /* dailyLevelDictionary.Add("rows", rows.ToString());
         dailyLevelDictionary.Add("columns", cols.ToString());
         dailyLevelDictionary.Add("puzzle", puzzle);*/
        row = rows;
        column = cols;
        gamePuzzle = puzzle;
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

