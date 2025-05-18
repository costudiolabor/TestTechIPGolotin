using TMPro;
using UnityEngine;

public class Build : MonoBehaviour {
    [SerializeField] private TMP_Text textCount;
    [SerializeField] private SpriteRenderer spriteResource;
    [SerializeField] private SettingBuild settingBuild;
    
    private int _count;
    private int _id;
    private Sprite _icon;
    private void Awake() { Initialize(); }
    public void Initialize() {
        _count = settingBuild.resource.count;
        _id = settingBuild.resource.id;
        _icon = settingBuild.resource.sprite;
        
        spriteResource.sprite = _icon;
        textCount.text = _count.ToString();
    }
    public Resource GetResources() => new Resource(_id, _count, _icon);
}