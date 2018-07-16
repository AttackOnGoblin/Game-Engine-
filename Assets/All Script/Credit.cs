using UnityEngine;
using UnityEngine.SceneManagement;
public class Credit : MonoBehaviour {
    public string leveltoload = "Credit Scene";

        public void play ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(leveltoload);
    }
}
