using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeManagerScript : MonoBehaviour {

    public static FadeManagerScript Instance { get; set; }

    public Image fadeImage;
    private bool isInTransition;
    private float transition;
    private bool isShowing;
    private float duration;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Fade(false, 2f); // false = hide , true = show
    }

    public void Fade (bool showing, float duration)
    {
        isShowing = showing;
        isInTransition = true;
        this.duration = duration;
        transition = (isShowing) ? 0 : 1; //isShowing false == 0, isShowing true == 1
    }

    void FixedUpdate()
    {
        if (!isInTransition)
            return;
        if (transition > 1 || transition < 0)
            isInTransition = false;

        if (fadeImage.color.a == 0)
        {
            fadeImage.enabled = false;
        }
    }

    void FadeBlackToTransparent()
    {

        if (!isInTransition)
            return;

        transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        fadeImage.color = new Color(1f, 1f, 1f, 1f);
        // fadeImage.GetComponent<Image>().color = Color.Lerp(new Color(0f,0f,0f,0f), new Color(0f,0f,0f,255f) , transition);
        Debug.Log(fadeImage.color.r + " " + fadeImage.color.g + " " + fadeImage.color.b + " " + fadeImage.color.a + " ");
        // Debug.Log(fadeImage.color.a);

    }
}
