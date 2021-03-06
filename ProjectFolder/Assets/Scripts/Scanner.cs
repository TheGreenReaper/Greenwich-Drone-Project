﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scanner : MonoBehaviour
{
    public GameObject centerPoint;
    public GameObject notificationPlane;
    public GameObject discoverPlane;
    // Use this for initialization

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 fwd = centerPoint.transform.position;
        if (Physics.Raycast(fwd, centerPoint.transform.forward, out hit, 50))
        {
            print(hit.collider.gameObject.name);
            if (hit.collider.gameObject.tag == "Building" && discoverPlane.activeInHierarchy == false)
            {
                notificationPlane.SetActive(true);
                if (Input.GetButtonDown("joystick button 7"))
                {
                    hit.collider.gameObject.GetComponent<ScanObject>().enabled = true;
                    notificationPlane.SetActive(false);
                }
                
            }
        }
        else
        {
            notificationPlane.SetActive(false);
            
        }

        if (Input.GetButtonDown("joystick button 5") && Input.GetButtonDown("joystick button 4"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
