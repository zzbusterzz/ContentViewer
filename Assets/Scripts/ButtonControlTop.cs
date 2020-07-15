using UnityEngine;
using UnityEngine.UI;


public class ButtonControlTop : MonoBehaviour {

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

    private int status = 0;//1 - On Settings, 2 - Levels

    private void Start()
    {
        VolumeSlider.onValueChanged.AddListener(OnVolumeChange);

        VolumeSlider.value = PlayerPrefs.GetFloat("Volume", 1);

        InititaliseUI();    
    }

    void InititaliseUI()
    {
      //  OnToggleAutoRotate();//Disables autorotate initially
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
        if(status == 0 || status == 2)
            InstructionPanel.gameObject.SetActive(!InstructionPanel.gameObject.activeInHierarchy);
        if (InstructionPanel.gameObject.activeInHierarchy)
        {
            status = 2;
            InstructionPanel.ShowLevels();
        }
        else
        {
            if (status == 2)
            {
                InstructionPanel.HideLevels();
                status = 0;
            }
        }
    }

    public void OnToggleSettingsWindow()
    {
        if (status == 0 || status == 1)
            InstructionPanel.gameObject.SetActive(!InstructionPanel.gameObject.activeInHierarchy);
        if (InstructionPanel.gameObject.activeInHierarchy)
        {
            status = 1;
            InstructionPanel.ShowSettings();
        }
        else
        {
            if (status == 1) {
                InstructionPanel.HideSettings();
                status = 0;
            }
        } 
    }

    private void Update()
    {
        if (autoRotate && ModelHandler != null)
        {
            ModelHandler.RotateModel();
        }
    }
}