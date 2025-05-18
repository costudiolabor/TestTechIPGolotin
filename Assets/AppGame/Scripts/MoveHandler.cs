using System;
using UnityEngine;

[Serializable]
public class MoveHandler {
    [SerializeField] private Transform thisTransform;
    [SerializeField] private float moveSpeed = 5f;
    private Vector3 _targetPosition;
    private bool _isMoving;
    
    public event Action<bool> MoveEvent;
    public event Action<bool> FlipEvent;
    
    public void SetTargetPosition(Vector3 targetPosition) {
        _targetPosition = targetPosition;
        _targetPosition.z = thisTransform.position.z;
        _isMoving = true;
    }
    public void OnUpdate() { Move(); }
    public void Move() {
        if (_isMoving && thisTransform.position != _targetPosition) {
            thisTransform.position = Vector3.MoveTowards(
                thisTransform.position, 
                _targetPosition, 
                moveSpeed * Time.deltaTime
            );
        }
        else { _isMoving = false; }
        
        if (_isMoving) {
            MoveEvent?.Invoke(true);
            Vector3 direction = _targetPosition - thisTransform.position;
            if (direction.x > 0)
                FlipEvent?.Invoke(false);
            else if (direction.x < 0)
                FlipEvent?.Invoke(true);
        }
        else {
            MoveEvent?.Invoke(false);
        }
    }
}