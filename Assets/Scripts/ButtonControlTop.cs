using UnityEngine;
using UnityEngine.UI;

public class ButtonControlTop : MonoBehaviour {

    public Image backgroundBG;

    public Slider volumeSlider;

    public Button volume;
    public Button rotateModel;
    public Button toggleLabel;
    public Button toggleVR;
    public Button toggleSubtitles;//Do nothing as of yet
    public Button toggleInstructions;//Do nothing as of yet
    public Button toggleSettingsWindow;

    public VolumeControl volumeControl;
    public ModelHandler modelHandler;

    public Sprite volumeButtonOn;
    public Sprite volumeButtonOff;

    public DisplayInstructions instructionPanel;

    private bool autoRotate = true;

    private LabelControl[] labelObjects;

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(OnVolumeChange);

        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1);

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

        volumeControl.UpdateVolumeSettings();
    }

    public void OnVolumeButtonClick()
    {
        int status = PlayerPrefs.GetInt("VolumeMute");
        if (status == 0)
        {
            volume.image.sprite = volumeButtonOn;
            PlayerPrefs.SetInt("VolumeMute", 1);
        }
        else
        {
            volume.image.sprite = volumeButtonOff;
            PlayerPrefs.SetInt("VolumeMute", 0);
        }
            
        PlayerPrefs.Save();

        volumeControl.UpdateVolumeSettings();
    }

    public void OnToggleAutoRotate()
    {
        autoRotate = !autoRotate;

        if (autoRotate)
        {
            rotateModel.image.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("1rotatetouch旋转");
        }
        else
        {
            rotateModel.image.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("2rotate旋转");
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
        RectTransform RT = instructionPanel.GetComponent<RectTransform>();

        RectTransformExtensions.SetLeft(RT, 1600);
        RectTransformExtensions.SetRight(RT, 100);

        if (instructionPanel.gameObject.activeInHierarchy)
        {
            if (DisplayInstructions.instance.GetWindowStatus() == 3)
                instructionPanel.HideWindow();
            else
                instructionPanel.ShowVROptions();
        }
        else
        {
            instructionPanel.ShowVROptions();
        }
    }

    public void OnToggleSubtitles()
    {
        //DO nothing
    }

    public void OnToggleLevel()
    {
        RectTransform RT = instructionPanel.GetComponent<RectTransform>();

        RectTransformExtensions.SetLeft(RT, 0);
        RectTransformExtensions.SetRight(RT, 1700);

        if (instructionPanel.gameObject.activeInHierarchy)
        {
            if (DisplayInstructions.instance.GetWindowStatus() == 2)
                instructionPanel.HideWindow();
            else
                instructionPanel.ShowLevels();
        }
        else
        {
            instructionPanel.ShowLevels();
        }
    }

    public void OnToggleInstructions()
    {
        //TODO
    }

    public void OnToggleSettingsWindow()
    {
        RectTransform RT = instructionPanel.GetComponent<RectTransform>();

        RectTransformExtensions.SetLeft(RT, 1700);
        RectTransformExtensions.SetRight(RT, 0);

        if (instructionPanel.gameObject.activeInHierarchy)
        {
            if (DisplayInstructions.instance.GetWindowStatus() == 1)
                instructionPanel.HideWindow();
            else
                instructionPanel.ShowSettings();
        }
        else
        {
            instructionPanel.ShowSettings();
        } 
    }

    private void Update()
    {
        if (autoRotate && modelHandler != null)
        {
            modelHandler.RotateModel();
        }
    }
}