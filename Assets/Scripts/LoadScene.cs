using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour {
	private const string sceneName = "LevelOne";

	public void Load() {
		SceneManager.LoadScene(sceneName);
	}

    public void MoveToPoint(Vector3 position)
    {
        Camera.main.transform.position = position;
    }
}
