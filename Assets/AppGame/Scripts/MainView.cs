using System;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour {
    [SerializeField] private Button buttonSetting; 
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Button buttonClose;  
    [SerializeField] private Toggle toggleSound;
    
    public event Action SettingEvent, CloseEvent;
    public event Action<bool> ToggleSoundEvent;
    public void Initialize() {
        buttonSetting.onClick.AddListener(OnSetting);
        buttonClose.onClick.AddListener(OnClose);
        toggleSound.onValueChanged.AddListener(OnToggleSound);
    }
    
    private void OnSetting() {
        settingsPanel.SetActive(true);
        SettingEvent?.Invoke();
    }
    
    private void OnClose() {
        settingsPanel.SetActive(false);
        CloseEvent?.Invoke();
    }
    
    private void OnToggleSound(bool state) {
        ToggleSoundEvent?.Invoke(state);
    }

    public void SetToggleState(bool isSound) {
        toggleSound.isOn = isSound;
    }
    
    private void OnDestroy() {
        buttonSetting.onClick.RemoveAllListeners();
        buttonClose.onClick.RemoveAllListeners();
        toggleSound.onValueChanged.RemoveAllListeners();
    }
}
