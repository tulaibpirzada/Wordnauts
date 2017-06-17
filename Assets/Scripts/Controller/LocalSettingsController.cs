using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LocalSettingsController : Singleton<LocalSettingsController>
{
    public static  LocalSettings GameSettings = new LocalSettings();

        public void SetSFxControl(bool value)
    {
        GameSettings.isSFXToggle = value;
       
    }

    public void SetAlertsControl(bool value)
    {
        GameSettings.isAlertsToggle = value;
        
    }
    //it's static so we can call it from anywhere
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd"); //you can call it anything you want
        bf.Serialize(file, GameSettings);
        file.Close();
    }

    public bool Load(ref LocalSettings settings)
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            GameSettings=(LocalSettings) bf.Deserialize(file);
            settings = GameSettings;
            file.Close();
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsSFXOn(LocalSettings settings)
    {
        return settings.isSFXToggle;
    }
    public bool IsAlertsOn(LocalSettings settings)
    {
        return settings.isAlertsToggle;
    }
}

