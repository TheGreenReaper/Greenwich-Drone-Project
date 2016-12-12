using UnityEngine;
using System.Collections;

public class SpeedCheck : MonoBehaviour {
    public Rigidbody drone;
    public Vector3 speed;
	// Use this for initialization
	void Start () {
        drone = transform.root.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        speed = drone.velocity;
	}
    void OnTriggerEnter(Collider other)
    {
        speed = drone.velocity;
    }
}
