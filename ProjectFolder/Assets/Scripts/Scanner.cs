using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{

    // Use this for initialization

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("FireRight"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit,25))
            {
                print(hit.collider.gameObject.name);
                if (hit.collider.gameObject.name == "King Williams Holo")
                {
                    hit.collider.gameObject.GetComponent<ScanObject>().enabled = true;
                }
                if (hit.collider.gameObject.name == "Queen Mary Holo")
                {
                    hit.collider.gameObject.GetComponent<ScanObject>().enabled = true;
                }
            }
        }
    }
}
