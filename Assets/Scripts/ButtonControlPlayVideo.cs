using UnityEngine;
using UnityEngine.UI;

public class ButtonControlPlayVideo : MonoBehaviour
{
    public Animator animator;//Aassign controlllelr here which willl handle animation of the model

    public Image bgImage;
    public Button PlayPauseButton;
    public Button StopButton;
    public Slider VideoSlider;

    public bool isPlaying = true;
    private bool isDragging = false;
    
    void Awake()
    {
        VideoSlider.onValueChanged.AddListener(OnVideoSlider);
    }

    // Use this for initialization
    void Start()
    {
        InitialiseButtonState();

        if(animator == null)
        {
            gameObject.SetActive(false);
        }
    }
        
    void InitialiseButtonState()
    {
        OnPlayPauseButton();//Disable animation

        if (StopButton != null)
            StopButton.image.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("stop");

        if(bgImage != null)
            bgImage.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("BG");

         //(VideoSlider.targetGraphic as Image).sprite = CommonUIComponents.instance.uIAtlas.GetSprite("stop");
    }


    public void OnPlayPauseButton()
    {
        isPlaying = !isPlaying;

        if (isPlaying)
        {
            PlayPauseButton.image.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("pause");
        }
        else
        {
            PlayPauseButton.image.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("play");
        }

        if (animator != null)
        {
            if (isPlaying)
                animator.speed = 1;
            else
                animator.speed = 0;
        }
    }

    public void OnStopButton()
    {
        //Do something
    }

    public void OnVideoSlider(float value)
    {
        //Change animation value
        if (isDragging)
        {
            animator.Play(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name, 0, value);
        }
    }

    public void OnBeginDrag()
    {
        animator.speed = 0;
        isDragging = true;
    }

    public void OnDrag()
    {
        isDragging = true;
    }

    public void OnEndDrag()
    {
        isDragging = false;
        if(isPlaying)
            animator.speed = 1;
    }

    private void Update()
    {
        if (isPlaying & !isDragging && animator != null)
        {
            VideoSlider.value = animator.GetCurrentAnimatorStateInfo(0).normalizedTime%1;
            //  Debug.Log("vallue : " + animator.GetCurrentAnimatorStateInfo(0).normalizedTime%1);
        }
    }
}
