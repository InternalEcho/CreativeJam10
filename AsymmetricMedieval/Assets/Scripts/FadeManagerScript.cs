using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FadeManagerScript : MonoBehaviour {

    public static FadeManagerScript Instance { get; set; }

    public Image fadeImage;
    public float fadeFactor;
    public float blackenFactor;
    private bool flagClear, flagBlack;
    private bool toBlackOver;

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
        flagClear = true;
        flagBlack = false;

        toBlackOver = false;
    }

    void Update()
    {
        if (flagClear)
            Fade();
        else if (flagBlack)
        {
            fadeImage.enabled = true;
            Blacken();
        }
    }

    void Blacken()
    {
        FadeToBlack();
        if (fadeImage.color.a >= 0.95f)
        {
            toBlackOver = true;
            Debug.Log("ToblackOver");
            fadeImage.color = Color.black;
            flagBlack = false;
            Debug.Log("Loading game!");
            SceneManager.LoadScene(1); //HARDCODE
        }
    }

    void FadeToBlack()
    {
        fadeImage.color = Color.Lerp(fadeImage.color, Color.black, blackenFactor * Time.deltaTime);
    }

    void Fade()
    {
        FadeToClear();

        if (fadeImage.color.a <= 0.07f)
        {
            fadeImage.color = Color.clear;
            fadeImage.enabled = false;
            flagClear = false;
        }

    }

    void FadeToClear()
    {
        fadeImage.color = Color.Lerp(fadeImage.color, Color.clear, fadeFactor * Time.deltaTime);
    }

    public void PlayTheGame()
    {
        flagBlack = true;
    }
}
