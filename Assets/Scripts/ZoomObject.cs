using UnityEngine;
using UnityEngine.UI;

public class ZoomObject : MonoBehaviour
{
    public static ZoomObject instance;

    public Slider s1, s2;

    [HideInInspector]
    public GameObject objectFocused;

    public void Start()
    {
        instance = this;

        s1.onValueChanged.AddListener(zoomInScene);
    }

    public void OnValueChange(Slider s)
    {
        if(s == s1)
        {
            s2.value = s1.value;
        }
        else
        {
            s1.value = s2.value;
        }
    }

    public void zoomInScene(float value)
    {
       // Debug.Log("Zoomed " + value);
        //Add zoom code

     //   Camera.main.transform.position = 
    }
}
