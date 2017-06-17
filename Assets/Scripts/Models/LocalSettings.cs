using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LocalSettings
{
    public bool isSFXToggle;
    public bool isAlertsToggle;

    public LocalSettings()
    {
        isSFXToggle = false;
        isAlertsToggle = false;
    }
}

