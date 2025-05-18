using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : View {
    [SerializeField] private List<ItemPopup> itemPopups;
    [SerializeField] private float delayShow = 1.0f;

    public void SetData(Resource[] resources) {
        ResetItems();
        SetDataItems(resources);
    }

    private void SetDataItems(Resource[] resources) {
        for (int i = 0; i < resources.Length; i++) {
            itemPopups[i].SetData(resources[i]);
            itemPopups[i].Show();
        }
    } 

    private void ResetItems() {
        for (int i = 0; i < itemPopups.Count; i++) { itemPopups[i].Hide(); }
    }
    
    public override void Show() {
        gameObject.SetActive(true);
        StartCoroutine(TimerShow());
    }

    private IEnumerator TimerShow() {
        yield return new WaitForSeconds(delayShow);
        Hide();
    }
}
