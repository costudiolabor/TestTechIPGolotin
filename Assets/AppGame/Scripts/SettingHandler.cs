using System;
using UnityEngine;

[Serializable]
public class SettingHandler {
    [SerializeField] private MainView mainView;

    public event Action OnSettingEvent, OnCloseEvent;
    public event Action<bool> ToggleSoundEvent;
    
    public void Initialize() {
        mainView.Initialize();
        Subscription();
    }
  
    private void OnMain() {
        OnSettingEvent?.Invoke();
    }
    
    private void OnClose() {
        OnCloseEvent?.Invoke();
    }
    
    private void OnToggleSound(bool state) {
        ToggleSoundEvent?.Invoke(state);
    }
    
    public void SetToggleState(bool isSound) {
        mainView.SetToggleState(isSound);
    }
    
    private void Subscription() {
        mainView.SettingEvent += OnMain;
        mainView.CloseEvent += OnClose;
        mainView.ToggleSoundEvent += OnToggleSound;
        
    }

    public void UnSubscription() {
        mainView.SettingEvent -= OnMain;
        mainView.CloseEvent -= OnClose;
        mainView.ToggleSoundEvent -= OnToggleSound;
    }

    
}
