using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject victoryUI;

    void Start()
    {
        GameIsOver = false;
    }

    void Update()
    {
     /* if(Input.GetKeyDown("p"))
        {
            GameOver();
        }

        if(Input.GetKeyDown("o"))
        {
            Victory();
        } */

        if(PlayerHealth.playerHealthValue <= 0 && !GameIsOver)
        {
            GameOver();
        }

        if(EnemyBaseHealth.enemyBaseHealthValue <= 0 && !GameIsOver)
        {
            Victory();
        }
    }

    void GameOver()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);

        //Debug.Log("Game!");
    }

    void Victory()
    {
        GameIsOver = true;
        victoryUI.SetActive(true);
    }
}
