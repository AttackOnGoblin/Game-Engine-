using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour {

   public static bool GameIsOver = false;

    public GameObject gameOverUI;

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
}
