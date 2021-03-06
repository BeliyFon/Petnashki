using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public void LoadScene()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Start": SceneManager.LoadScene("Game", LoadSceneMode.Single); break;
            case "Game": SceneManager.LoadScene("Start", LoadSceneMode.Single); break;
        }
    }

    public void Shuffle()
    {
        Global.count = 0;
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                Global.board[row, col] = 0;
            }
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Close()
    {
        Application.Quit();
    }
}
