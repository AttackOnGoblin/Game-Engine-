using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour {

    public string leveltoload2 = "MainScene";

    public void StartLevel()
    {
        SceneManager.LoadScene(leveltoload2);
    }
}
