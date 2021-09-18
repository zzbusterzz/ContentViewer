using UnityEngine;

public class LabelControl : MonoBehaviour
{
    public TextMesh TM;
    public LineRenderer LR;
    public float OffsetX = 0.05f;
    public float OffsetY = 0.05f;

    [Range(1.0f, 100f)]
    public float scaleMult = 1.0f;

    private MeshFilter filter;

    private void Start()
    {
        TM.text = transform.parent.name;
        TM.transform.localScale *= scaleMult;
        filter = transform.parent.GetComponent<MeshFilter>();
        PlaceLabelBesides();

    }

    public void ToggleLabel()
    {
        TM.gameObject.SetActive(!TM.gameObject.activeSelf);
        LR.gameObject.SetActive(!LR.gameObject.activeSelf);
    }

    void PlaceLabelBesides()
    {
        Transform parent = transform.parent;
        GameObject refObj = GameObject.FindGameObjectWithTag("RefPoint");
        if (refObj == null)
            refObj = parent.gameObject;

        Vector3 wp = parent.TransformPoint(filter.sharedMesh.bounds.center);
        Vector3 posRelToMesh = Vector3.zero;
        float width = GetWidth(TM) * TM.transform.localScale.x;

        if (refObj.transform.position.x <= parent.position.x)
        {
            //Place label in right
            posRelToMesh = wp + new Vector3( width/2 + OffsetX, OffsetY, 0);

            TM.anchor = TextAnchor.MiddleLeft;
        }
        else if (refObj.transform.position.x > parent.position.x)
        {
            //place object in left
            posRelToMesh = wp - new Vector3( width/2 + OffsetX, OffsetY, 0);
            TM.anchor = TextAnchor.MiddleRight;
        }
        TM.transform.position = posRelToMesh;
        
        LR.SetPosition(0, wp);
        
    }

    private void Update()
    {
        TM.transform.LookAt(Camera.main.transform.position + new Vector3(0,0, 180) );
        Vector3 wp = transform.parent.TransformPoint(filter.sharedMesh.bounds.center);
        LR.SetPosition(0, wp);
        LR.SetPosition(1, TM.transform.position);
    }


    public static float GetWidth(TextMesh mesh)
    {
        float width = 0;
        foreach (char symbol in mesh.text)
        {
            CharacterInfo info;
            if (mesh.font.GetCharacterInfo(symbol, out info, mesh.fontSize, mesh.fontStyle))
            {
                width += info.advance;
            }
        }
        return width * mesh.characterSize * 0.1f;
    }
}
