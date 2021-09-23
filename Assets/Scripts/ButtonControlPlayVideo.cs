using UnityEngine;
using UnityEngine.UI;

public class ButtonControlPlayVideo : MonoBehaviour
{
    public Animator animator;//Aassign controlllelr here which willl handle animation of the model

    public Image bgImage;
    public Button playPauseButton;
    public Button stopButton;
    public Slider videoSlider;

    public bool isPlaying = true;
    private bool isDragging = false;
    
    void Awake()
    {
        videoSlider.onValueChanged.AddListener(OnVideoSlider);
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

        if (stopButton != null)
            stopButton.image.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("stop");

        if(bgImage != null)
            bgImage.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("BG");

         //(VideoSlider.targetGraphic as Image).sprite = CommonUIComponents.instance.uIAtlas.GetSprite("stop");
    }


    public void OnPlayPauseButton()
    {
        isPlaying = !isPlaying;

        if (isPlaying)
        {
            playPauseButton.image.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("pause");
        }
        else
        {
            playPauseButton.image.sprite = CommonUIComponents.instance.uIAtlas.GetSprite("play");
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
            videoSlider.value = animator.GetCurrentAnimatorStateInfo(0).normalizedTime%1;
            //  Debug.Log("vallue : " + animator.GetCurrentAnimatorStateInfo(0).normalizedTime%1);
        }
    }
}
