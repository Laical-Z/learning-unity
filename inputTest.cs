using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.A)) {
            Debug.Log("A");
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            Debug.Log("A Down");
        }

        if (Input.GetKeyUp(KeyCode.A)) {
            Debug.Log("A Up");
        }

        if (Input.GetMouseButton(0)) {
            Debug.Log("Left");
        }

        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Left Down");
        }

        if (Input.GetMouseButtonUp(0)) {
            Debug.Log("Left Up");
        }
	}
}
