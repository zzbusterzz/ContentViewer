using UnityEngine;

public class CarEngineModelHandler : ModelHandler
{
    enum ActiveState
    {
        Model1,
        Model2,
        Both
    }

    public GameObject engineMain;
    public GameObject engineStroke;

    void Start()
    {
        ButtonOnePressed(FirstButtonToSelect);
    }

    /// <summary>
    /// Show Only engine Main
    /// </summary>
    public override void ButtonOnePressed(GameObject Button)
    {
        SetActiveState(ActiveState.Model1, Button);
        engineStroke.GetComponent<Animation>().Stop();
    }

    /// <summary>
    /// Show First Stroke Animation
    /// </summary>
    public override void ButtonTwoPressed(GameObject Button)
    {
        SetActiveState(ActiveState.Model2, Button);
        engineStroke.GetComponent<Animation>().Play("Stroke1");
    }

    /// <summary>
    /// Show Second Stroke Animation
    /// </summary>
    public override void ButtonThreePressed(GameObject Button)
    {
        SetActiveState(ActiveState.Model2, Button);
        engineStroke.GetComponent<Animation>().Play("Stroke2");
    }

    /// <summary>
    /// Show Third Stroke Animation
    /// </summary>
    public override void ButtonFourPressed(GameObject Button)
    {
        SetActiveState(ActiveState.Model2, Button);
        engineStroke.GetComponent<Animation>().Play("Stroke3");
    }

    /// <summary>
    /// Show Fourth Stroke Animation
    /// </summary>
    public override void ButtonFivePressed(GameObject Button)
    {
        SetActiveState(ActiveState.Model2, Button);
        engineStroke.GetComponent<Animation>().Play("Stroke4");
    }

    /// <summary>
    /// Show Both Models and animation
    /// </summary>
    public override void ButtonSixPressed(GameObject Button)
    {
        SetActiveState(ActiveState.Both, Button);
        engineStroke.GetComponent<Animation>().Play("qiyouji_all");
    }


    void SetActiveState(ActiveState activeState, GameObject currentPressedButton)
    {
        SelectButton(currentPressedButton);

        engineMain.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));

        switch (activeState)
        {
            case ActiveState.Both:
                engineMain.SetActive(true);
                engineStroke.SetActive(true);
                activeModel = transform.gameObject;
                engineStroke.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                break;

            case ActiveState.Model1:
                engineMain.SetActive(true);
                engineStroke.SetActive(false);
                activeModel = engineMain;
                engineStroke.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                break;

            case ActiveState.Model2:
                engineMain.SetActive(false);
                engineStroke.SetActive(true);
                activeModel = engineStroke;

                engineStroke.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                break;
        }
    }
}

