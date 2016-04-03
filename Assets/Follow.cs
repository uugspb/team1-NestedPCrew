using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
        Vector3 cameraPosition = Camera.main.transform.position;
        this.transform.position = new Vector3(cameraPosition.x, this.transform.position.y, cameraPosition.z);
	}
}
