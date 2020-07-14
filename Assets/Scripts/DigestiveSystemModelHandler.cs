using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ModelInfo
{
    public GameObject model;
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale = Vector3.one;

    public GameObject cameraEnd;

    private Vector3 localPosition;
    private Quaternion localRotation;
    private Vector3 localscale;

    private Transform parentModel;

    private Vector3 localCamPosition;
    private Quaternion localCamRotation;

    public void SaveDefaultValues()
    {
        parentModel = model.transform.parent;
        localPosition = model.transform.localPosition;
        localRotation = model.transform.localRotation;
        localscale = model.transform.localScale;

        localCamPosition = cameraEnd.transform.localPosition;
        localCamRotation = cameraEnd.transform.localRotation;
    }

    public void PushModelFront()
    {
        model.transform.parent = null;
        model.transform.position = position;
        model.transform.rotation = Quaternion.Euler(rotation);
        model.transform.localScale = scale;

        cameraEnd.transform.parent = null;
    }

    public void ResetModel()
    {
        model.transform.parent = parentModel.transform;
        model.transform.localPosition = localPosition;
        model.transform.localRotation = localRotation;
        model.transform.localScale = localscale;

        cameraEnd.transform.parent = model.transform;
        cameraEnd.transform.localPosition = localCamPosition;
        cameraEnd.transform.localRotation = localCamRotation;

    }
}

public class DigestiveSystemModelHandler : ModelHandler
{
    enum ActiveState
    {
        DigestiveSystem,
        OralCavity,
        Oesophagus,
        Stomach,
        Small_intestine,
        Large_intestine,
        Short_animation
    }

    public List<ModelInfo> modelInfo;

    // Use this for initialization
    public override void Start()
    {
        base.Start();

        for(int i = 0; i < modelInfo.Count; i++)
            modelInfo[i].SaveDefaultValues();

        ButtonOnePressed(FirstButtonToSelect);
    }

    /// <summary>
    /// Show All digestive system
    /// </summary>
    public override void ButtonOnePressed(GameObject Button)
    {
        base.ButtonOnePressed(Button);

        SetActiveState(ActiveState.DigestiveSystem, Button);
    }

    /// <summary>
    /// Show OralCavity
    /// </summary>
    public override void ButtonTwoPressed(GameObject Button)
    {
        base.ButtonTwoPressed(Button);

        SetActiveState(ActiveState.OralCavity, Button);
    }

    /// <summary>
    /// Show oesopagus
    /// </summary>
    public override void ButtonThreePressed(GameObject Button)
    {
        base.ButtonThreePressed(Button);

        SetActiveState(ActiveState.Oesophagus, Button);
    }

    /// <summary>
    /// Show Stomach
    /// </summary>
    public override void ButtonFourPressed(GameObject Button)
    {
        base.ButtonFourPressed(Button);

        SetActiveState(ActiveState.Stomach, Button);
    }

    /// <summary>
    /// Show small intestine
    /// </summary>
    public override void ButtonFivePressed(GameObject Button)
    {
        base.ButtonFivePressed(Button);

        SetActiveState(ActiveState.Small_intestine, Button);
    }

    /// <summary>
    /// Show Large Intestine
    /// </summary>
    public override void ButtonSixPressed(GameObject Button)
    {
        base.ButtonSixPressed(Button);

        SetActiveState(ActiveState.Large_intestine, Button);
    }

    /// <summary>
    /// Show Animation
    /// </summary>
    public override void ButtonSevenPressed(GameObject Button)
    {
        base.ButtonSevenPressed(Button);

        SetActiveState(ActiveState.Short_animation, Button);
    }

    /// <summary>
    /// Sets the current active model
    /// </summary>
    void SetActiveState(ActiveState activeState, GameObject currentPressedButton)
    {
        for (int i = 0; i < modelInfo.Count; i++)
        {
            if (modelInfo[i].model == activeModel)
            {
                modelInfo[i].ResetModel();
                break;
            }
        }

        if (activeState == ActiveState.Short_animation)
        {
            activeModel = modelInfo[0].model;
            for (int i = 0; i < modelInfo.Count; i++)
                modelInfo[i].model.SetActive(true);

            return;
        }

        activeModel = modelInfo[(int)activeState].model;
        modelInfo[(int)activeState].PushModelFront();

        if (activeState == ActiveState.DigestiveSystem)
        {
            for (int i = 0; i < modelInfo.Count; i++)
                modelInfo[i].model.SetActive(true);
        }
        else
        {
            for (int i = 0; i < modelInfo.Count; i++)
            {
                if (activeModel != modelInfo[i].model)
                    modelInfo[i].model.SetActive(false);
                else
                    modelInfo[i].model.SetActive(true);
            }
        }

    }
}