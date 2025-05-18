using System;
using UnityEngine;

[Serializable]
public class PopupHandler {
    [SerializeField] private Popup popup;
    
    public void SetData(Resource[] data) => popup.SetData(data);
    public void Show() => popup.Show();
}