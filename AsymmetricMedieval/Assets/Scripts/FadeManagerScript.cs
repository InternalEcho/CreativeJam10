using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeManagerScript : MonoBehaviour {

    public static FadeManagerScript Instance { get; set; }

    public Image fadeImage;
    public float fadeFactor;
    private bool flag;

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
        flag = true;
    }

    void Update()
    {
        if (flag)
          Fade();
    }

    void Blacken()
    {
        FadeToBlack();
        if (fadeImage.color.a >= 254f)
        {
            fadeImage.color = Color.clear;
            fadeImage.enabled = false;
            flag = false;
        }
    }

    void FadeToBlack()
    {
        fadeImage.color = Color.Lerp(fadeImage.color, Color.black, fadeFactor * Time.deltaTime);
    }

    void Fade()
    {
        FadeToClear();

        if (fadeImage.color.a <= 0.1f)
        {
            fadeImage.color = Color.clear;
            fadeImage.enabled = false;
            flag = false;
        }
    }

    void FadeToClear()
    {
        fadeImage.color = Color.Lerp(fadeImage.color, Color.clear, fadeFactor * Time.deltaTime);
    }
}
