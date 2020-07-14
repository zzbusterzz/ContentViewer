using UnityEngine;
using UnityEngine.UI;

public class ZoomObject : MonoBehaviour
{
    public static ZoomObject instance;

    public Slider s1, s2;

    [HideInInspector]
    public GameObject objectFocused;

    private Vector3 positonCamera;

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
        Camera.main.transform.position = Vector3.Lerp(positonCamera, objectFocused.transform.position, value);
    }

    public void storeCameraPosition()
    {
        positonCamera = Camera.main.transform.position;
    }

    public void ResetPosition()
    {
        s1.value = s2.value = 0;
    }
}
