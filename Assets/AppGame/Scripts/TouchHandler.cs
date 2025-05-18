using System;
using UnityEngine;

[Serializable]
public class TouchHandler {
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float sensitive = 0.01f;
    
    public event Action DragEvent;
    public event Action<Vector3> ClickEvent;
    public event Action<Vector2> ChangeDragEvent;

    private Vector2 _currentPosition;
    private Vector2 _lastPosition;
    private bool _firstClick;
    private bool _isDrag;
    
    public void OnUpdate() {
        UpdateMouseButtons();
        DragEvent?.Invoke();
    }
    
    private void UpdateMouseButtons() {
        if (Input.GetMouseButtonDown(0)) {
            DragEvent += Drag;
            _lastPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0)) {
            Click();
            _firstClick = false;
            _isDrag = false;
            DragEvent -= Drag;
        }
    }

    private void Click() {
        if (_isDrag) return;
        Vector3 targetPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        ClickEvent?.Invoke(targetPosition);
    }

    private void Drag() {
        _currentPosition = Input.mousePosition;
        if (_currentPosition != _lastPosition) _isDrag = true;
        if (_firstClick == false) {
            _lastPosition = _currentPosition;
            _firstClick = true;
        }
        Vector2 delta = _currentPosition - _lastPosition;
        ChangeDragEvent?.Invoke(delta * sensitive);
        _lastPosition = _currentPosition;
    }
}
