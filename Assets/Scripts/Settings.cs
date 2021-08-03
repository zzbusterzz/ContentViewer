using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public enum SupportedLanguges
{
    English,
    Chinese
}

public class Settings : MonoBehaviour
{
    public static Settings instance;

    public SupportedLanguges currentLanguage = SupportedLanguges.Chinese;

    public Slider rotationSlider;

    public Dropdown language;

    public _3DMethod _3DMethod = _3DMethod.None;

    public Toggle none;
    public Toggle SBS;
    public Toggle Anaglyph;

    private float rotationMultiplier = 0.1f;

    void Awake()
    {
        instance = this;

        int selectedLang = PlayerPrefs.GetInt("Language", 0); ;

        if(selectedLang == 0)
            currentLanguage = SupportedLanguges.Chinese;
        else
            currentLanguage = SupportedLanguges.English;

        switch (currentLanguage)
        {
            case SupportedLanguges.English:
                SetLocalization("English");
                language.value = 1;
                break;

            case SupportedLanguges.Chinese:
                SetLocalization("Chinese");
                language.value = 0;
                break;
        }

        rotationSlider.value = rotationMultiplier;
    }

    private void Start()
    {
        language.onValueChanged.AddListener(OnDropDownChange);
        rotationSlider.onValueChanged.AddListener(OnValueChange);

        none.onValueChanged.AddListener(OnToggleChange);
        SBS.onValueChanged.AddListener(OnToggleChange);
        Anaglyph.onValueChanged.AddListener(OnToggleChange);

    }

    /// <summary>
    /// Change localization at runtime
    /// </summary>
    public void SetLocalization(string localization)
    {
        LocalizationManager.Language = localization;
    }

    public void OnValueChange(float value)
    {
        rotationMultiplier = value;
    }

    public void OnToggleChange(bool toogleStatus)
    {
        if (toogleStatus)
        {
            if (none.isOn)
                Stereo3D.instance.S3DEnabled = false;
            else if (SBS.isOn)
            {
                Stereo3D.instance.S3DEnabled = true;
                Stereo3D.instance.method = _3DMethod.SideBySide;
            }                
            else if (Anaglyph.isOn)
            {
                Stereo3D.instance.S3DEnabled = true;
                Stereo3D.instance.method = _3DMethod.Anaglyph;
            }
        }
    }

    public float getRotation()
    {
        return rotationMultiplier;
    }

    public void OnDropDownChange(int value)
    {
        switch (value)
        {
            case 0:
                SetLocalization("Chinese");
                PlayerPrefs.SetInt("Language", 0);
                break;

            case 1:
                SetLocalization("English");
                PlayerPrefs.SetInt("Language", 1);
                break;
        }
    }
}
