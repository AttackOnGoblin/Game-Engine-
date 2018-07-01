using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

    public string leveltoLoad = "Select Level";

	public void Play()
    {
        SceneManager.LoadScene(leveltoLoad);
    }

    public void Quit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

}
