using UnityEngine;
using UnityEngine.UI;

public class TopPanelControl : MonoBehaviour
{
    public Image topBG;
    public Image iconImage;
    public Button close;
    public Button restore;
    public Button minimise;

    void Start()
    {
        InitialiseUI();
    }
  
    void InitialiseUI()
    {        
        topBG.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("topBarBG");//problem here need to fix image
        iconImage.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("naughtylogo公司logo");
        close.image.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("close关闭");
        restore.image.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("restore最大化");
        minimise.image.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("minimise最小化");
    }       
}
