using System;
using UnityEngine;

[Serializable]
public class SoundHandler {
    [SerializeField] private AudioListener listener;

    public void SetStateAudioListener(bool state) {
        listener.enabled = state;
    }
}
