using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;


public class DatabaseModel : Singleton<DatabaseModel>
{
    public string dbPath= "https://wordpuzzle-a3ac5.firebaseio.com/";
    public string dailyPackName = "daily_level_pack";
    public string presPackName = "prestige_level_pack";
    public string regPackName = "regular_level_packs";
    public string subLevelName = "level_list";
    public bool userExists = false;
    public DataSnapshot dailyLevelSnapshot;
    public DataSnapshot userDataSnapshot;
}
