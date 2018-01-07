using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManagementScript : MonoBehaviour {

    public enum StateType
    {
        MAIN,
        GAME,
        DEAD,
        GAMEOVER,
        END
    };

    [Header("Game Logic")]
    public StateType state;
    public int playerLives = 2;

    [Header("In-game UI")]
    public Image heart1;
    public Image heart2;
    public GameObject gameOverScreen;
    public Text gameOverText;
    public GameObject endButtons;

    public static GameManagementScript Instance { get; private set; }

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
        gameOverScreen = GameObject.FindGameObjectWithTag("GameOver");
        gameOverText.enabled = false;
        endButtons = GameObject.FindGameObjectWithTag("EndButtons");
        GoToMain();
    }

    void Update()
    {
        switch (state)
        {
            case StateType.MAIN :
                break;
            case StateType.GAME :

                if (playerLives == 2)
                {
                    heart1.enabled = true;
                    heart2.enabled = true;
                }
                else if (playerLives == 1)
                {
                    heart1.enabled = false;
                    heart2.enabled = true;                   
                }
                else 
                {
                    heart1.enabled = false;
                    heart2.enabled = false;
                    GoToDead();
                }

                break;
            
            case StateType.DEAD :

                break;

            case StateType.END :
                break;

            default :
                break;
        }
    }

    public void GoToMain()
    {
        resetAll();
        state = StateType.MAIN;
    }

    public void GoToGame()
    {
        Debug.Log("Play Game");
        StartCoroutine(BeginGame());
    }

    IEnumerator BeginGame()
    {
        resetAll();
        //FadeManagerScript.Instance.flagBlack = true;
        state = StateType.GAME;
        SceneManager.LoadScene(1);
        FadeManagerScript.Instance.flagClear = true;
        yield return null;
    }

    public void GoToDead()
    {
        state = StateType.DEAD;
        StartCoroutine(deathAnimation());
    }

    public void GoToGameOver()
    {
        state = StateType.GAMEOVER;
        SceneManager.LoadScene(2);
        StartCoroutine(ShowGameOver());
    }

    IEnumerator deathAnimation()
    {
        FadeManagerScript.Instance.flagBlack = true;
        yield return new WaitForSeconds(6f);
        Debug.Log("disable fade image");
        GoToGameOver();
    }

    IEnumerator ShowGameOver()
    {
        gameOverScreen.GetComponent<Image>().enabled = true;
        gameOverText.enabled = true;
        yield return new WaitForSeconds(2f);
        endButtons.SetActive(true);

    }

    void resetAll()
    {
        playerLives = 2;
        heart1.enabled = false;
        heart2.enabled = false;
        gameOverScreen.GetComponent<Image>().enabled = false;
        gameOverText.enabled = false;
        endButtons.SetActive(false);
        FadeManagerScript.Instance.reset();
        StopAllCoroutines();
    }

    public void ReloadMain()
    {
        Debug.Log("Going To Main");
        FadeManagerScript.Instance.fadeImage.enabled = true;
        if (FadeManagerScript.Instance.fadeImage.enabled == true)
            Debug.Log("oui");

        else
            Debug.Log("non");
        FadeManagerScript.Instance.flagClear = true;
        GoToMain();
    }
}
