using UnityEngine;
using UnityEngine.U2D;

public class CommonUIComponents : MonoBehaviour
{
    public static CommonUIComponents instance;

    public SpriteAtlas uIAtlas;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
}
