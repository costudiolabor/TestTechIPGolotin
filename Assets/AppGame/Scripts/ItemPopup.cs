using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopup : View {
    [SerializeField] private RawImage imageResource;
    [SerializeField] private TMP_Text textCount;

    public void SetData(Resource data) {
        imageResource.texture = data.sprite.texture;
        textCount.text = data.count.ToString();
    }
}
