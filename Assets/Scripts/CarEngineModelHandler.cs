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

    public ButtonControlPlayVideo animationPlayinstance;

   // private Animator engineMain_Anim;
    private Animator engineStroke_Anim;

    public override void Start()
    {
        base.Start();
        engineStroke_Anim = engineStroke.GetComponent<Animator>();
        ButtonOnePressed(FirstButtonToSelect);
    }

    /// <summary>
    /// Show Only engine Main
    /// </summary>
    public override void ButtonOnePressed(GameObject Button)
    {
        base.ButtonOnePressed(Button);

        SetActiveState(ActiveState.Model1, Button);        
    }

    /// <summary>
    /// Show First Stroke Animation
    /// </summary>
    public override void ButtonTwoPressed(GameObject Button)
    {
        base.ButtonOnePressed(Button);

        SetActiveState(ActiveState.Model2, Button);
        engineStroke_Anim.Play("Stroke1");
        engineStroke_Anim.SetBool("All", false);
        engineStroke_Anim.SetBool("One", true);
        engineStroke_Anim.SetBool("Two", false);
        engineStroke_Anim.SetBool("Three", false);
        engineStroke_Anim.SetBool("Four", false);

    }

    /// <summary>
    /// Show Second Stroke Animation
    /// </summary>
    public override void ButtonThreePressed(GameObject Button)
    {
        base.ButtonOnePressed(Button);

        SetActiveState(ActiveState.Model2, Button);
        engineStroke_Anim.Play("Stroke2");
        engineStroke_Anim.SetBool("All", false);
        engineStroke_Anim.SetBool("One", false);
        engineStroke_Anim.SetBool("Two", true);
        engineStroke_Anim.SetBool("Three", false);
        engineStroke_Anim.SetBool("Four", false);
    }

    /// <summary>
    /// Show Third Stroke Animation
    /// </summary>
    public override void ButtonFourPressed(GameObject Button)
    {
        base.ButtonOnePressed(Button);

        SetActiveState(ActiveState.Model2, Button);
        engineStroke_Anim.Play("Stroke3");
        engineStroke_Anim.SetBool("All", false);
        engineStroke_Anim.SetBool("One", false);
        engineStroke_Anim.SetBool("Two", false);
        engineStroke_Anim.SetBool("Three", true);
        engineStroke_Anim.SetBool("Four", false);
    }

    /// <summary>
    /// Show Fourth Stroke Animation
    /// </summary>
    public override void ButtonFivePressed(GameObject Button)
    {
        base.ButtonOnePressed(Button);

        SetActiveState(ActiveState.Model2, Button);
        engineStroke_Anim.Play("Stroke4");
        engineStroke_Anim.SetBool("All", false);
        engineStroke_Anim.SetBool("One", false);
        engineStroke_Anim.SetBool("Two", false);
        engineStroke_Anim.SetBool("Three", false);
        engineStroke_Anim.SetBool("Four", true);
    }

    /// <summary>
    /// Show Both Models and animation
    /// </summary>
    public override void ButtonSixPressed(GameObject Button)
    {
        base.ButtonOnePressed(Button);

        SetActiveState(ActiveState.Both, Button);
        engineStroke_Anim.Play("StrokeEngine_All");
        engineStroke_Anim.SetBool("All", true);
        engineStroke_Anim.SetBool("One", false);
        engineStroke_Anim.SetBool("Two", false);
        engineStroke_Anim.SetBool("Three", false);
        engineStroke_Anim.SetBool("Four", false);
    }

    void SetActiveState(ActiveState activeState, GameObject currentPressedButton)
    {
        //engineMain.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        engineMain.transform.parent.localRotation = Quaternion.identity;

        switch (activeState)
        {
            case ActiveState.Both:
                engineMain.SetActive(true);
                engineStroke.SetActive(true);
                activeModel = transform.gameObject;
                
                Vector3 pos = engineMain.transform.parent.localPosition;
                engineMain.transform.parent.localPosition = new Vector3(-0.02500007f, pos.y, pos.z);

                pos = engineStroke.transform.localPosition;
                engineStroke.transform.localPosition = new Vector3(0.35f, pos.y, pos.z);
                engineStroke.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                break;

            case ActiveState.Model1:
                engineMain.SetActive(true);
                engineStroke.SetActive(false);
                activeModel = engineMain;

                pos = engineMain.transform.parent.localPosition;
                engineMain.transform.parent.localPosition = new Vector3(-0.02500007f, pos.y, pos.z);

                pos = engineStroke.transform.localPosition;
                engineStroke.transform.localPosition = new Vector3(0.35f, pos.y, pos.z);
                engineStroke.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                break;

            case ActiveState.Model2:
                engineMain.SetActive(false);
                engineStroke.SetActive(true);
                activeModel = engineStroke;
                
                pos = engineMain.transform.parent.localPosition;
                engineMain.transform.parent.localPosition = new Vector3(0, pos.y, pos.z);

                pos = engineStroke.transform.localPosition;
                engineStroke.transform.localPosition = new Vector3(0, pos.y, pos.z);
                engineStroke.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                break;
        }

        animationPlayinstance.animator = activeModel.GetComponent<Animator>();
    }

    public override void RotateModel()
    {
        if (!activeModel) return;

        if(activeModel == engineMain)
            activeModel.transform.parent.Rotate(Vector3.up, -rotateMultiplier);
        else
            activeModel.transform.Rotate(Vector3.up, -rotateMultiplier);

    }
}

