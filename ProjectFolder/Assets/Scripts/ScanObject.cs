﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanObject : MonoBehaviour
{
    Material mat;
    public Material notMaterial;
    Color color;
    float t;
    int time;
    bool notificationShown = false;
    public GameObject notificationsPlane;
    public GameObject actualBuilding;
	// Use this for initialization
	void Start () {
        
        mat = GetComponent<Renderer>().material;
        color = mat.color;
        color.a = 0.4f;
        InvokeRepeating("Fade", 0, 0.01f);
        StartCoroutine(Notification());
        
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Renderer>().material.color = color;


	}
    void Fade()
    {
        if (notificationShown == false)
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
            color.a += 0.004f * t;
        }
    }
    IEnumerator Notification()
    {
        notificationsPlane.GetComponent<Renderer>().material = notMaterial;
        yield return new WaitForSeconds(6);
        notificationShown = true;
        color.a = 0;
        notificationsPlane.SetActive(true);
        actualBuilding.SetActive(true);
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(3);
        notificationsPlane.SetActive(false);
        Destroy(gameObject);
    }
}
