using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ModelInfo
{
    public GameObject model;
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale = Vector3.one;

    private Vector3 localPosition;
    private Quaternion localRotation;
    private Vector3 localscale;

    private Transform parentModel;
    
    public void SaveDefaultValues()
    {
        parentModel = model.transform.parent;
        localPosition = model.transform.localPosition;
        localRotation = model.transform.localRotation;
        localscale = model.transform.localScale;
    }

    public void PushModelFront()
    {
        model.transform.parent = null;
        model.transform.position = position;
        model.transform.rotation = Quaternion.Euler(rotation);
        model.transform.localScale = scale;
    }

    public void ResetModel()
    {
        model.transform.parent = parentModel.transform;
        model.transform.localPosition = localPosition;
        model.transform.localRotation = localRotation;
        model.transform.localScale = localscale;
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
    void Start()
    {
        for(int i = 0; i < modelInfo.Count; i++)
            modelInfo[i].SaveDefaultValues();

        ButtonOnePressed(FirstButtonToSelect);
    }

    /// <summary>
    /// Show All digestive system
    /// </summary>
    public override void ButtonOnePressed(GameObject Button)
    {
        SetActiveState(ActiveState.DigestiveSystem, Button);
    }

    /// <summary>
    /// Show OralCavity
    /// </summary>
    public override void ButtonTwoPressed(GameObject Button)
    {
        SetActiveState(ActiveState.OralCavity, Button);
    }

    /// <summary>
    /// Show oesopagus
    /// </summary>
    public override void ButtonThreePressed(GameObject Button)
    {
        SetActiveState(ActiveState.Oesophagus, Button);
    }

    /// <summary>
    /// Show Stomach
    /// </summary>
    public override void ButtonFourPressed(GameObject Button)
    {
        SetActiveState(ActiveState.Stomach, Button);
    }

    /// <summary>
    /// Show small intestine
    /// </summary>
    public override void ButtonFivePressed(GameObject Button)
    {
        SetActiveState(ActiveState.Small_intestine, Button);
    }

    /// <summary>
    /// Show Large Intestine
    /// </summary>
    public override void ButtonSixPressed(GameObject Button)
    {
        SetActiveState(ActiveState.Large_intestine, Button);
    }

    /// <summary>
    /// Show Animation
    /// </summary>
    public override void ButtonSevenPressed(GameObject Button)
    {
        SetActiveState(ActiveState.Short_animation, Button);
    }

    /// <summary>
    /// Sets the current active model
    /// </summary>
    void SetActiveState(ActiveState activeState, GameObject currentPressedButton)
    {
        SelectButton(currentPressedButton);

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