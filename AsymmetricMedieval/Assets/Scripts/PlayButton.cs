using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayButton : MonoBehaviour {

	public void GoToGame (int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    
}
