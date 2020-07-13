using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public enum SupportedLanguges
{
    English,
    Chinese
}

public class ButtonControlTop : MonoBehaviour {

    public SupportedLanguges currentLanguage = SupportedLanguges.Chinese;

    public Image backgroundBG;

    public Slider VolumeSlider;

    public Button Volume;
    public Button RotateModel;
    public Button ToggleLabel;
    public Button ToggleVR;
    public Button ToggleSubtitles;//Do nothing as of yet
    public Button ToggleInstructions;//Do nothing as of yet
    public Button ToggleSettingsWindow;

    public VolumeControl VolumeControl;
    public ModelHandler ModelHandler;

    public Sprite VolumeButtonOn;
    public Sprite VolumeButtonOff;

    public DisplayInstructions InstructionPanel;

    private bool autoRotate = true;

    void Awake()
    {
        

        switch (currentLanguage)
        {
            case SupportedLanguges.English:
                SetLocalization("English");
                break;

            case SupportedLanguges.Chinese:
                SetLocalization("Chinese");
                break;
        }
    }

    private void Start()
    {
        VolumeSlider.onValueChanged.AddListener(OnVolumeChange);

        VolumeSlider.value = PlayerPrefs.GetFloat("Volume", 1);

        InititaliseUI();    
    }

    /// <summary>
    /// Change localization at runtime
    /// </summary>
    public void SetLocalization(string localization)
    {
        LocalizationManager.Language = localization;
    }


    void InititaliseUI()
    {
        OnToggleAutoRotate();//Disables autorotate initially
    }

    public void OnVolumeChange(float value)
    {
        PlayerPrefs.SetFloat("Volume", value);
        PlayerPrefs.Save();

        VolumeControl.UpdateVolumeSettings();
    }

    public void OnVolumeButtonClick()
    {
        int status = PlayerPrefs.GetInt("VolumeMute");
        if (status == 0)
        {
            Volume.image.sprite = VolumeButtonOn;
            PlayerPrefs.SetInt("VolumeMute", 1);
        }
        else
        {
            Volume.image.sprite = VolumeButtonOff;
            PlayerPrefs.SetInt("VolumeMute", 0);
        }
            
        PlayerPrefs.Save();

        VolumeControl.UpdateVolumeSettings();
    }

    public void OnToggleAutoRotate()
    {
        autoRotate = !autoRotate;

        if (autoRotate)
        {
            RotateModel.image.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("1rotatetouch旋转");
        }
        else
        {
            RotateModel.image.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("2rotate旋转");
        }
    }


    public void OnToggleLabel()
    {

    }

    public void OnToggleVR()
    {

    }

    public void OnToggleSubtitles()
    {
        //DO nothing
    }

    public void OnToggleInstructions()
    {
        InstructionPanel.gameObject.SetActive(!InstructionPanel.gameObject.activeInHierarchy);
        if (InstructionPanel.gameObject.activeInHierarchy)
        {
            InstructionPanel.DisplayInstructionsOnPanel();
        }
    }

    public void OnToggleSettingsWindow()
    {
       
    }

    private void Update()
    {
        if (autoRotate && ModelHandler != null)
        {
            ModelHandler.RotateModel();
        }
    }
}