using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour {
	private const string sceneName = "LevelOne";

    private GameObject[] highlights;
    private GameObject[] points;

    [SerializeField]
    private GameObject startPoint;

    private static LoadScene _instance;
    public static LoadScene Instance
    {
        get { return _instance; }
    }
    void Awake()
    {
        highlights = GameObject.FindGameObjectsWithTag("highlight");
        points = GameObject.FindGameObjectsWithTag("point");
        if(_instance != null)
        {
            GameObject.Destroy(_instance.gameObject);
        }
        _instance = this;
        HideAll();
        startPoint.SetActive(true);
    }

	public void Load() {
		SceneManager.LoadScene(sceneName);
	}

    public void HideAll()
    {
        for (int i = 0; i < highlights.Length; i++)
        {
            highlights[i].SetActive(false);
        }

        for (int i = 0; i < points.Length; i++)
        {
            points[i].SetActive(false);
        }
    }
}
