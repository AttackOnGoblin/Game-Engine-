using UnityEngine;
using UnityEngine.SceneManagement;

public class BacktoMenu : MonoBehaviour {
    public string leveltoload = "Main Menu";

    public void BackMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(leveltoload);    
    }


}
