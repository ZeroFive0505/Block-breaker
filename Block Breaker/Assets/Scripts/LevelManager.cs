using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {


    public void GameStart(string level)
    {
        print("Game Start!");
        Application.LoadLevel(level);
    }

    public void GameQuit()
    {
        print("Quit the game");
        Application.Quit();
    }

    public void NextLevel(string level)
    {
        Brick.brickCount = 0;
        Application.LoadLevel(level);
    }

    public void LoadNextLevel()
    {
        Brick.brickCount = 0;
        Application.LoadLevel(Application.loadedLevel+1);
    }

    public void Try_again()
    {
        Application.LoadLevel(LoseCollider.Stage);
    }

    public void BrickDestroyed()
    {
        if (Brick.brickCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
