using Assets.SimpleLocalization;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInstructions : MonoBehaviour
{
    public static DisplayInstructions instance;

    public Transform attachToComponent;
    public GameObject prefab;

    private Transform buttonLevelHolder;
    private Transform buttonSettingsHolder;
    private Transform buttonVRHolder;

    private int status = 0;//0 closed

    void Awake()
    {
        instance = this;

        buttonLevelHolder = new GameObject().transform;
        buttonSettingsHolder = new GameObject().transform;
        buttonVRHolder = new GameObject().transform;

        buttonLevelHolder.gameObject.SetActive(false);
        buttonSettingsHolder.gameObject.SetActive(false);
        buttonVRHolder.gameObject.SetActive(false);

        status = 2;

        HideWindow();       
    }

    public int GetWindowStatus()
    {
        return status;
    }

    public void HideWindow()
    {
        List<Transform> listofT = new List<Transform>();
        foreach (Transform child in attachToComponent)
        {
            listofT.Add(child);
        }

        foreach (Transform child in listofT)
        {
            switch(child.tag)
            {
                case "Settings":
                    child.SetParent(buttonSettingsHolder);
                    break;
                case "VRSettings":
                    child.SetParent(buttonVRHolder);
                    break;
                case "Level":
                    child.SetParent(buttonLevelHolder);
                    break;
            }
        }
        status = 0;
        gameObject.SetActive(false);
    }

    public void DisplayInstructionsOnPanel()
    {
        
    }

    public void ShowVROptions()
    {
        CheckOpenWindow();

        status = 3;

        List<Transform> listofT = new List<Transform>();
        foreach (Transform child in buttonVRHolder)
        {
            listofT.Add(child);
        }

        foreach (Transform child in listofT)
        {
            child.SetParent(attachToComponent);
        }
    }


    public void ShowSettings()
    {
        CheckOpenWindow();

        status = 1;

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



    public void ShowLevels()
    {
        CheckOpenWindow();

        status = 2;

        if (buttonLevelHolder.childCount == 0)
        {
            int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
            string[] scenes = new string[sceneCount];
            for (int i = 0; i < sceneCount; i++)
            {
                scenes[i] = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i));
                Button sceneButtons = Instantiate<GameObject>(prefab, attachToComponent).GetComponent<Button>();
                sceneButtons.tag = "Level";
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

    void CheckOpenWindow()
    {
        if(status > 0)
        {
            HideWindow();
        }
        gameObject.SetActive(true);
    }

    void CallbackLoad(Button button)
    {
        Debug.Log("Loading scene  :" + button.name);
        UnityEngine.SceneManagement.SceneManager.LoadScene(button.name);
    }
}
