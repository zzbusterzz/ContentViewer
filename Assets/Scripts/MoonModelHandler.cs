using UnityEngine;

public class MoonModelHandler : ModelHandler
{
    public GameObject moonRender;

	// Use this for initialization
	void Start ()
    {
        moonRender.SetActive(false);
    }

    public override void ButtonTwoPressed(GameObject Button)
    {
        moonRender.SetActive(!moonRender.activeSelf);
    }
}
