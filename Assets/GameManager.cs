using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour {

   public static bool gameEnded = false;

	void Update () {

        if (gameEnded)
            return;

		if (PLayerStats.Life <= 0)
        {
            EndGame();
        }
	}
    void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over");
    }
}
