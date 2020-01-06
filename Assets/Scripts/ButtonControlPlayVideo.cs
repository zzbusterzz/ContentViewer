using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonControlPlayVideo : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image bgImage;
    public Button PlayPauseButton;
    public Button StopButton;
    public Slider VideoSlider;

    public bool isPlaying = false;
    private bool isDragging = false;
    
    void Awake()
    {
       
    }

    // Use this for initialization
    void Start()
    {
        InitialiseButtonState();
    }

    void InitialiseButtonState()
    {
        SetSpriteOfPlayPause();

        if(StopButton != null)
            StopButton.image.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("stop");

        if(bgImage != null)
            bgImage.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("BG");

         (VideoSlider.targetGraphic as Image).sprite = CommonUIComponents.instance.uIAtlas.GetSprite("stop");
    }

    public void OnPlayPauseButton()
    {
        isPlaying = !isPlaying;
        SetSpriteOfPlayPause();
    }

    void SetSpriteOfPlayPause()
    {
        if (isPlaying)
        {
            PlayPauseButton.image.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("play");
        }
        else
        {
            PlayPauseButton.image.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("pause");
        }
    }

    public void OnStopButton()
    {
        //Do something
    }

    public void OnVideoSlider(float value)
    {
        //Change animation value
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
    }
}
