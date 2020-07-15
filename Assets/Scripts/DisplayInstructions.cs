using Assets.SimpleLocalization;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInstructions : MonoBehaviour
{
    public Transform attachToComponent;
    public GameObject prefab;

    private Transform buttonLevelHolder;
    private Transform buttonSettingsHolder;

    private int status = 0;//0 closed

    void Awake()
    {
        buttonLevelHolder = new GameObject().transform;
        buttonSettingsHolder = new GameObject().transform;

        buttonLevelHolder.gameObject.SetActive(false);
        buttonSettingsHolder.gameObject.SetActive(false);

        status = 2;
    }

    public void DisplayInstructionsOnPanel()
    {
        
    }

    public void ShowSettings()
    {
        CheckOpenWindow();

        status = 2;

        List<Transform> listofT = new List<Transform>();
        foreach (Transform child in buttonSettingsHolder)
        {
            listofT.Add(child);
        }

        foreach(Transform child in listofT)
        {
            child.SetParent(attachToComponent);
        }
     
    }

    public void HideSettings()
    {
        List<Transform> listofT = new List<Transform>();
        foreach (Transform child in attachToComponent)
        {
            listofT.Add(child);
        }

        foreach (Transform child in listofT)
        {
            child.SetParent(buttonSettingsHolder);
        }
        status = 0;
    }

    public void ShowLevels()
    {
        CheckOpenWindow();

        status = 1;

        if (buttonLevelHolder.childCount == 0)
        {
            int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
            string[] scenes = new string[sceneCount];
            for (int i = 0; i < sceneCount; i++)
            {
                scenes[i] = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i));
                Button sceneButtons = Instantiate<GameObject>(prefab, attachToComponent).GetComponent<Button>();
                sceneButtons.name = scenes[i];
                sceneButtons.onClick.AddListener(() => CallbackLoad(sceneButtons));
                LocalizedText text = sceneButtons.GetComponentInChildren<Text>().gameObject.AddComponent<LocalizedText>();
                text.LocalizationKey = sceneButtons.name;
            }
        }
        else
        {

            List<Transform> listofT = new List<Transform>();
            foreach (Transform child in buttonLevelHolder)
            {
                listofT.Add(child);
            }

            foreach (Transform child in listofT)
            {
                child.SetParent(attachToComponent);
            }
        }
    }

    public void HideLevels()
    {
        List<Transform> listofT = new List<Transform>();
        foreach (Transform child in attachToComponent)
        {
            listofT.Add(child);
        }

        foreach (Transform child in listofT)
        {
            child.SetParent(buttonLevelHolder);
        }
               
        status = 0;
    }

    void CheckOpenWindow()
    {
        switch (status)
        {
            case 1:
                HideLevels();
                break;

            case 2:
                HideSettings();
                break;

            default:
                break;
        }
    }

    void CallbackLoad(Button button)
    {
        Debug.Log("Loading scene  :" + button.name);
        UnityEngine.SceneManagement.SceneManager.LoadScene(button.name);
    }
}
