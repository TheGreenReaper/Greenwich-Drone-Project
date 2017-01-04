using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanObject : MonoBehaviour
{
    Material mat;
    Color color;
    float t;
    int time;
    public GameObject notificationsPlane;
    GameObject instant;
	// Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>().material;
        color = mat.color;
        color.a = 0.4f;
        InvokeRepeating("Fade", 0, 0.01f);
        Invoke("SpawnNotifications", 4.5f);
        
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Renderer>().material.color = color;


	}
    void Fade()
    {
        if (instant == null)
        {
            if (color.a < 0)
            {
                color.a = 0;
            }
            if (color.a > 0.4f)
            {
                color.a = 0.4f;
            }
            if (color.a == 0)
            {
                t = 1;
            }
            if (color.a == 0.4f)
            {
                t = -1;
            }
            color.a += 0.01f * t;
        }
    }
    void SpawnNotifications()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        instant = Instantiate(notificationsPlane, player.transform, player.transform);
        instant.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 8);
        
        Destroy(instant, 5);
        Destroy(gameObject, 5.1f);
    }
}
