using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCheckScript : MonoBehaviour {
    public Transform player;
    float distance = 150;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(player.position, transform.position) < distance)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
	}
}
