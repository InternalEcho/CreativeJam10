using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManagementScript : MonoBehaviour {

    public enum StateType
    {
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
        GoToGame();
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

    void GoToGame()
    {
        state = StateType.GAME;
        resetAll();
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
