using System;
using UnityEngine;

[Serializable]
public class PlayerHandler {
    [SerializeField] private Player player;
    public event Action<Resource> AddResourceEvent;
    public void Initialize() {
        player.Initialize();
        Subscription();
    }
    public void OnUpdate() { player.OnUpdate(); }
    public void SetTargetPosition(Vector3 targetPosition)=> player.SetTargetPosition(targetPosition);
    private void OnAddResource(Resource resource) {
        AddResourceEvent?.Invoke(resource);
    }
    private void Subscription() {
        player.AddResourceEvent += OnAddResource;
    }
    public void UnSubscription() {
        player.AddResourceEvent -= OnAddResource;
        player.UnSubscription();
    }
}