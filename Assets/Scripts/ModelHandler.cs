using UnityEngine;
using UnityEngine.UI;

public class ModelHandler : MonoBehaviour {
    [HideInInspector]
    public GameObject activeModel = null;

    public GameObject B1Focus, B2Focus, B3Focus, B4Focus, B5Focus, B6Focus, B7Focus;

    public Transform CameraPos1, CameraPos2, CameraPos3, CameraPos4, CameraPos5, CameraPos6, CameraPos7;

    public GameObject AnimationClipPlayer;

   // public float rotateMultiplier = 5.0f;

    public GameObject FirstButtonToSelect;

    public ColorBlock NormalTransition;
    public ColorBlock SelectedTransition;

    private GameObject PreviousButton;

    // Use this for initialization
    public virtual void Start () {
        Debug.Log(ZoomObject.instance.name);

        if(B1Focus != null)
            ZoomObject.instance.objectFocused = B1Focus;
    }

    public virtual void RotateModel()
    {
        if (!activeModel) return;

        activeModel.transform.Rotate    (Vector3.up, -Settings.instance.getRotation());
        
    }


    public virtual void SelectButton(GameObject currentPressedButton)
    {
        currentPressedButton.GetComponent<Button>().colors = SelectedTransition;

        if (PreviousButton && PreviousButton != currentPressedButton)
        {
            PreviousButton.GetComponent<Button>().colors = NormalTransition;
        }

        PreviousButton = currentPressedButton;
    }

    public virtual void ButtonOnePressed(GameObject Button)
    {
        SelectButton(Button);

        ZoomObject.instance.objectFocused = B1Focus;

        Camera.main.transform.position = CameraPos1.position;

        ZoomObject.instance.ResetPosition();
    }

    public virtual void ButtonTwoPressed(GameObject Button)
    {
        SelectButton(Button);

        ZoomObject.instance.objectFocused = B2Focus;

        Camera.main.transform.position = CameraPos2.position;

        ZoomObject.instance.ResetPosition();
    }

    public virtual void ButtonThreePressed(GameObject Button)
    {
        SelectButton(Button);

        ZoomObject.instance.objectFocused = B3Focus;

        Camera.main.transform.position = CameraPos3.position;

        ZoomObject.instance.ResetPosition();
    }

    public virtual void ButtonFourPressed(GameObject Button)
    {
        SelectButton(Button);

        ZoomObject.instance.objectFocused = B4Focus;

        Camera.main.transform.position = CameraPos4.position;

        ZoomObject.instance.ResetPosition();
    }

    public virtual void ButtonFivePressed(GameObject Button)
    {
        SelectButton(Button);

        ZoomObject.instance.objectFocused = B5Focus;

        Camera.main.transform.position = CameraPos5.position;

        ZoomObject.instance.ResetPosition();
    }

    public virtual void ButtonSixPressed(GameObject Button)
    {
        SelectButton(Button);

        ZoomObject.instance.objectFocused = B6Focus;

        Camera.main.transform.position = CameraPos6.position;

        ZoomObject.instance.ResetPosition();
    }

    public virtual void ButtonSevenPressed(GameObject Button)
    {
        SelectButton(Button);

        ZoomObject.instance.objectFocused = B7Focus;

        Camera.main.transform.position = CameraPos7.position;

        ZoomObject.instance.ResetPosition();
    }
}
