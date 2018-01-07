using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FadeManagerScript : MonoBehaviour {

    public static FadeManagerScript Instance { set; get; }

    public Image fadeImage;
    public float fadeFactor;
    public float blackenFactor;
    public bool flagClear, flagBlack;
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
        {
            fadeImage.enabled = true;
            Fade();
        }
        else if (flagBlack)
        {
            fadeImage.enabled = true;
            Blacken();
        }
    }

    public void Blacken()
    {
        FadeToBlack();
        Debug.Log(fadeImage.color.a);
        if (fadeImage.color.a >= 0.95f)
        {
            toBlackOver = true;
            Debug.Log("ToblackOver");
            fadeImage.color = Color.black;
            flagBlack = false;
            Debug.Log("Loading game!");
            if (GameManagementScript.Instance.state == GameManagementScript.StateType.MAIN)
            {
            //    GameManagementScript.Instance.GoToGame(); //HARDCODE
            }
            else if (GameManagementScript.Instance.state == GameManagementScript.StateType.DEAD)
            {
                fadeImage.enabled = false;
                GameManagementScript.Instance.GoToGameOver();
            }
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

    public void reset()
    {

        flagClear = true;
        flagBlack = false;
        toBlackOver = false;
        fadeImage.color = Color.black;
    }

}
