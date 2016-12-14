using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrCameraControl : MonoBehaviour {
    public Transform camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            transform.Translate(camera.forward);
        }
        //if (Input.GetButton("Tap"))
        //{
        //    transform.Translate(camera.forward * Time.deltaTime);
        //}
	}
}
