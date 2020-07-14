using UnityEngine;

public class MoonModelHandler : ModelHandler
{
    public GameObject moonRender;

	// Use this for initialization
	public override void Start ()
    {
        base.Start();
        moonRender.SetActive(false);
    }

    public override void ButtonTwoPressed(GameObject Button)
    {
      //  base.ButtonTwoPressed(Button);
        moonRender.SetActive(!moonRender.activeSelf);
    }
}
