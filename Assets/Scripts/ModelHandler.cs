﻿using UnityEngine;
using UnityEngine.UI;

public class ModelHandler : MonoBehaviour {
    [HideInInspector]
    public GameObject activeModel = null;

    public GameObject B1Focus, B2Focus, B3Focus, B4Focus, B5Focus, B6Focus, B7Focus;

    public GameObject AnimationClipPlayer;

    public float rotateMultiplier = 5.0f;

    public GameObject FirstButtonToSelect;

    public ColorBlock NormalTransition;
    public ColorBlock SelectedTransition;

    private GameObject PreviousButton;

    // Use this for initialization
    void Start () {
		
	}

    public void RotateModel()
    {
        if (!activeModel) return;

        activeModel.transform.Rotate    (Vector3.up, -rotateMultiplier);
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
    }

    public virtual void ButtonTwoPressed(GameObject Button)
    {
        SelectButton(Button);

        ZoomObject.instance.objectFocused = B1Focus;
    }

    public virtual void ButtonThreePressed(GameObject Button)
    {
        SelectButton(Button);

        ZoomObject.instance.objectFocused = B1Focus;
    }

    public virtual void ButtonFourPressed(GameObject Button)
    {
        SelectButton(Button);

        ZoomObject.instance.objectFocused = B1Focus;
    }

    public virtual void ButtonFivePressed(GameObject Button)
    {
        SelectButton(Button);

        ZoomObject.instance.objectFocused = B1Focus;
    }

    public virtual void ButtonSixPressed(GameObject Button)
    {
        SelectButton(Button);

        ZoomObject.instance.objectFocused = B1Focus;
    }

    public virtual void ButtonSevenPressed(GameObject Button)
    {
        SelectButton(Button);

        ZoomObject.instance.objectFocused = B1Focus;
    }
}
