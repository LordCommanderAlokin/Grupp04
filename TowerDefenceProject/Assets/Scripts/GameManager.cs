using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool GameIsEnded;

    void Start()
    {
        GameIsEnded = false;
    }

    public GameObject gameOverUI;
    public GameObject gameWonUI;

    void Update () {
        if (GameIsEnded)
            return;
        
		if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
	}

    void EndGame()
    {
        GameIsEnded = true;

        gameOverUI.SetActive(true);
    }
    public void WinGame()
    {
        GameIsEnded = true;

        gameWonUI.SetActive(true);
    }
}
