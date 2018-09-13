using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEntry : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GridManager.Instance.Initialize();
        GridManager.Instance.InstantiateGridObjects();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
