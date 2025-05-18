using UnityEngine;

public class EntryPoint : MonoBehaviour {
    [SerializeField] private TouchHandler touchHandler;
    [SerializeField] private CameraHandler cameraHandler;
    [SerializeField] private PlayerHandler playerHandler;
    [SerializeField] private ResourcesHandler resourcesHandler;
    [SerializeField] private PopupHandler popupHandler;
    [SerializeField] private SettingHandler settingHandler;
    [SerializeField] private StorageService storageService = new StorageService();
    [SerializeField] private SoundHandler soundHandler;
    
    void Awake() { Initialize(); }

    private void Initialize() {
        playerHandler.Initialize();
        settingHandler.Initialize();
        SetupSound();
        Subscription();
    }

    private void SetupSound() {
        bool isSound = storageService.GetSettingSound();
        soundHandler.SetStateAudioListener(isSound);
        settingHandler.SetToggleState(isSound);
    }

    void Update() {
        touchHandler.OnUpdate();
        playerHandler.OnUpdate();
    }

    private void OnClick(Vector3 targetPosition) {
        playerHandler.SetTargetPosition(targetPosition);
    } 
    
    private void OnScroll(Vector2 delta) {
        cameraHandler.OnScroll(delta);
    }

    private void OnAddResource(Resource resource) {
        resourcesHandler.AddResource(resource);
        Resource[] data = resourcesHandler.GetResources();
        popupHandler.SetData(data);
        popupHandler.Show();
    }
    
    private void OnSetting() {
        touchHandler.ChangeDragEvent -= OnScroll;
        touchHandler.ClickEvent -= OnClick;
    }
    
    private void OnClose() {
        touchHandler.ChangeDragEvent += OnScroll;
        touchHandler.ClickEvent += OnClick;
    }
    
    private void OnChangeSound(bool state) {
        storageService.SetSettingSound(state);
        soundHandler.SetStateAudioListener(state);
    }
    
    private void Subscription() {
        playerHandler.AddResourceEvent += OnAddResource;
        touchHandler.ChangeDragEvent += OnScroll;
        touchHandler.ClickEvent += OnClick;
        settingHandler.OnSettingEvent += OnSetting;
        settingHandler.OnCloseEvent += OnClose;
        settingHandler.ToggleSoundEvent += OnChangeSound;
    }
   
    private void UnSubscription() {
        playerHandler.AddResourceEvent -= OnAddResource;
        touchHandler.ChangeDragEvent -= OnScroll;
        touchHandler.ClickEvent -= OnClick;
        settingHandler.OnSettingEvent -= OnSetting;
        settingHandler.OnCloseEvent -= OnClose;
        settingHandler.ToggleSoundEvent -= OnChangeSound;
        settingHandler.UnSubscription();
        playerHandler.UnSubscription();
    }

    private void OnDestroy() { UnSubscription(); }
    
}