using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControlTop : MonoBehaviour {
    public Text ChapterName;

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
    }

    private void Start()
    {
        VolumeSlider.onValueChanged.AddListener(OnVolumeChange);

        ChapterName.text = SceneManager.GetActiveScene().name;
        VolumeSlider.value = PlayerPrefs.GetFloat("Volume", 1);   
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


