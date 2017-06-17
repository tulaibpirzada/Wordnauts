using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LocalSettingsController : Singleton<LocalSettingsController>
{
    //public static  LocalSettings GameSettings = new LocalSettings();

    //it's static so we can call it from anywhere
    public void Save(bool sfx, bool alert)
    {
        LocalSettings.Instance.isSFXToggle = sfx;
        LocalSettings.Instance.isAlertsToggle = alert;
        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd"); //you can call it anything you want
        bf.Serialize(file, LocalSettings.Instance);
        file.Close();
    }

    public bool Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            bf.Deserialize(file);
            file.Close();
            return true;
        }
        else
        {
            return false;
        }
    }

}

