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
        GAMEOVER,
        END
    };

    [Header("Game Logic")]
    [SerializeField]
    private StateType state;
    public int playerLives = 2;

    [Header("In-game UI")]
    public Image heart1;
    public Image heart2;

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
        GoToMain();
    }

    void Update()
    {
        switch (state)
        {
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
                    GoToGameOver();
                }

                break;
            
            case StateType.GAMEOVER :

                break;

            case StateType.END :
                break;

            default :
                break;
        }
    }

    void GoToMain()
    {
        state = StateType.MAIN;
        SceneManager.LoadScene(0);
        FadeManagerScript.Instance.Fade();
        resetAll();

    }

    void GoToGame()
    {
        state = StateType.GAME;
        SceneManager.LoadScene(1);
    }

    void GoToGameOver()
    {
        state = StateType.GAMEOVER;
    }

    void resetAll()
    {
        playerLives = 2;
    }

}
