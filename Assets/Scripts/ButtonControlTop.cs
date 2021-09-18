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

    private LabelControl[] labelObjects;

    private void Start()
    {
        VolumeSlider.onValueChanged.AddListener(OnVolumeChange);

        VolumeSlider.value = PlayerPrefs.GetFloat("Volume", 1);

        InititaliseUI();

        GameObject[] lObj =  GameObject.FindGameObjectsWithTag("Label");

        if(lObj != null && lObj.Length != 0)
        {
            labelObjects = new LabelControl[lObj.Length];

            for(int i = 0; i < labelObjects.Length; i++)
            {
                labelObjects[i] = lObj[i].GetComponent<LabelControl>();
            }
        }
        
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
        if (labelObjects == null || labelObjects.Length == 0) return;

        for(int i = 0; i < labelObjects.Length; i++)
        {
            labelObjects[i].ToggleLabel();
        }
    }

    public void OnToggleVR()
    {
        RectTransform RT = InstructionPanel.GetComponent<RectTransform>();

        RectTransformExtensions.SetLeft(RT, 1600);
        RectTransformExtensions.SetRight(RT, 100);

        if (InstructionPanel.gameObject.activeInHierarchy)
        {
            if (DisplayInstructions.instance.GetWindowStatus() == 3)
                InstructionPanel.HideWindow();
            else
                InstructionPanel.ShowVROptions();
        }
        else
        {
            InstructionPanel.ShowVROptions();
        }
    }

    public void OnToggleSubtitles()
    {
        //DO nothing
    }

    public void OnToggleLevel()
    {
        RectTransform RT = InstructionPanel.GetComponent<RectTransform>();

        RectTransformExtensions.SetLeft(RT, 0);
        RectTransformExtensions.SetRight(RT, 1700);

        if (InstructionPanel.gameObject.activeInHierarchy)
        {
            if (DisplayInstructions.instance.GetWindowStatus() == 2)
                InstructionPanel.HideWindow();
            else
                InstructionPanel.ShowLevels();
        }
        else
        {
            InstructionPanel.ShowLevels();
        }
    }

    public void OnToggleInstructions()
    {
      
    }

    public void OnToggleSettingsWindow()
    {
        RectTransform RT = InstructionPanel.GetComponent<RectTransform>();

        RectTransformExtensions.SetLeft(RT, 1700);
        RectTransformExtensions.SetRight(RT, 0);

        if (InstructionPanel.gameObject.activeInHierarchy)
        {
            if (DisplayInstructions.instance.GetWindowStatus() == 1)
                InstructionPanel.HideWindow();
            else
                InstructionPanel.ShowSettings();
        }
        else
        {
            InstructionPanel.ShowSettings();
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