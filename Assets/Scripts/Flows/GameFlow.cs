using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour {
    InputManager inputManager;

    // Use this for initialization
    void Start () {
        inputManager = new InputManager();
	}
	
	// Update is called once per frame
	void Update () {
        inputManager.GetInputs();

    }
}
