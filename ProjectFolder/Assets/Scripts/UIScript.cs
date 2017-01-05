using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {
    public Text height;
    public Text speed;
    public Text autoPilot;
    GameObject player;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        height.text = "Height: " + player.transform.position.y.ToString("F2");
        speed.text = "Speed: " + "\n X: " + GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().velocity.x.ToString("F1")
            + "\n Y: " + GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().velocity.y.ToString("F1")
            + "\n Y: " + GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().velocity.z.ToString("F1");
    }
}
