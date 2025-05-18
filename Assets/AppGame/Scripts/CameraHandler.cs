using System;
using UnityEngine;

[Serializable]
public class CameraHandler {
    [SerializeField] private Transform cameraTransform;
    
    public void OnScroll(Vector2 delta) {
        cameraTransform.Translate(-delta);
    }
}
