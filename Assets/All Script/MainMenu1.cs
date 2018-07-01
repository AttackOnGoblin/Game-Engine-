using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu1 : MonoBehaviour {

    public string leveltoLoad = "MainScene";

	public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(leveltoLoad);
    }


}
