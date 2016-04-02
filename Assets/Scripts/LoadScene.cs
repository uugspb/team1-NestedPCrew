using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour {

	public string sceneName = "Main";

	public void Load () {
		SceneManager.LoadScene (sceneName);
	}

	public void Load (string _name) {
		sceneName = _name;
		Load ();
	}
	

}
