using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour {
	private const string sceneName = "LevelOne";

    [SerializeField]
    private GameObject startGamePoint;
    
    [SerializeField]
    private GameObject movePoint;
	public void Load() {
		SceneManager.LoadScene(sceneName);
	}

    public void ShowGameStartPoint()
    {
        movePoint.SetActive(false);
        startGamePoint.SetActive(true);
    }
}
