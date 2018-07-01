using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour {

    public GameObject ui;

	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
	}
    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if(ui.activeSelf)
        {
            Time.timeScale = 0f;
        }else
        {
            Time.timeScale = 1f; 
        }
    }
    public void restart()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        Toggle();
        SceneManager.LoadScene("Main Menu");
    }
}
