using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scanner : MonoBehaviour
{
    public GameObject centerPoint;
    public GameObject notificationPlane;
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
            if (hit.collider.gameObject.tag == "Building")
            {
                if (Input.GetButtonDown("FireRight") || Input.GetKey("w"))
                {
                    print(hit.collider.gameObject.name);
                    if (hit.collider.gameObject.name == "King Williams Holo")
                    {
                        hit.collider.gameObject.GetComponent<ScanObject>().enabled = true;
                    }
                    if (hit.collider.gameObject.name == "Queen Anne Holo")
                    {
                        hit.collider.gameObject.GetComponent<ScanObject>().enabled = true;
                    }
                }
                notificationPlane.SetActive(true);
            }
        }
        else
        {
            notificationPlane.SetActive(false);
        }

        if (Input.GetButtonDown("Reset") || Input.GetMouseButtonDown(1))
        {
            float i = QualitySettings.lodBias;
            string lodDetail = i.ToString("F2");
            print(lodDetail);
            switch (lodDetail)
            {
                case "0.50":
                    QualitySettings.lodBias = 0.1f;
                    break;
                case "0.25":
                    QualitySettings.lodBias = 0.50f;
                    break;
                case "0.10":
                    QualitySettings.lodBias = 0.25f;
                    break;
                
            }
        }
    }
}
