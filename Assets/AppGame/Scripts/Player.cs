using System;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private MoveHandler moveHandler;
    [SerializeField] private SpriteRenderer body;
    [SerializeField] private Animator animator;
    [SerializeField] private string walkState = "Walk";

    public event Action<Resource> AddResourceEvent;

    public void Initialize() { Subscription(); }
    public void SetTargetPosition(Vector3 targetPosition)=> moveHandler.SetTargetPosition(targetPosition);
    public void OnUpdate() { moveHandler.OnUpdate(); }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent(out Build build)) {
            var resource = build.GetResources();
            AddResourceEvent?.Invoke(resource);
        }
    }
    private void Subscription() {
        moveHandler.MoveEvent += OnMove;
        moveHandler.FlipEvent += OnFlip;
    }
    private void OnMove(bool state) { animator.SetBool(walkState, state); }
    private void OnFlip(bool state) { body.flipX = state; }
    public void UnSubscription() {
        moveHandler.MoveEvent -= OnMove;
        moveHandler.FlipEvent -= OnFlip;
    }
    
}
