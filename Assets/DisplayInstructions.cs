using UnityEngine;
using UnityEngine.UI;

public class DisplayInstructions : MonoBehaviour
{
    public Transform attachToComponent;
    public GameObject prefab;

    public void DisplayInstructionsOnPanel()
    {
        ShowLevels();
    }

    void ShowLevels()
    {
        if(attachToComponent.childCount == 0)
        {
            int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
            string[] scenes = new string[sceneCount];
            for (int i = 0; i < sceneCount; i++)
            {
                scenes[i] = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i));
                Button sceneButtons = Instantiate<GameObject>(prefab, attachToComponent).GetComponent<Button>();
                sceneButtons.name = sceneButtons.GetComponentInChildren<Text>().text = scenes[i];
                sceneButtons.onClick.AddListener(() => CallbackLoad(sceneButtons));
            }
        }
    }

    void CallbackLoad(Button button)
    {
        Debug.Log("Loading scene  :" + button.name);
        UnityEngine.SceneManagement.SceneManager.LoadScene(button.name);
    }
}
