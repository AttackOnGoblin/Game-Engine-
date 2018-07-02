using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

   public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject levelCompleteUI;

    public string nextLevel = "Map 2";
    public int levelToUnlock = 2;

    void start()
    {
        GameIsOver = false;
    }


	void Update () {

        if (GameIsOver)
            return;

		if (PLayerStats.Life <= 0)
        {
            EndGame();
        }
	}
    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameIsOver = true;
        levelCompleteUI.SetActive(true);
    
    }
}
