using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;

    // Update is called once per frame
    void Update()
    {
        if(PlayerHealth.playerHealthValue <= 0 && !gameEnded)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game!");
        gameEnded = true;
    }
}
