using System;
using UnityEngine;

[Serializable]
public class StorageService {
    public void SetSettingSound(bool state) {
        int isSound = 0;
        if (state == true) isSound = 1;
        PlayerPrefs.SetInt("SoundState", isSound);
    }

    public bool GetSettingSound() {
        return PlayerPrefs.GetInt("SoundState", 1) == 1;
    }
}
