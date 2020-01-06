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

    private bool isButtonRotatePressed = false;

    void Awake()
    {
        InititaliseUI();

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

    public void OnRotateModelDown()
    {
        isButtonRotatePressed = true;
    }

    public void OnRotateModelUp()
    {
        isButtonRotatePressed = false;
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
        //Do nothing
    }

    public void OnToggleSettingsWindow()
    {
       
    }

    private void Update()
    {
        if (isButtonRotatePressed)
        {
            ModelHandler.RotateModel();
        }
    }
}


