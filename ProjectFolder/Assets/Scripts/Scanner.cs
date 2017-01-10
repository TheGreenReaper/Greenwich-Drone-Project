using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scanner : MonoBehaviour
{
    public GameObject light;
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

            if (Physics.Raycast(ray, out hit, 50))
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
        if (Input.GetButtonDown("Reset") || Input.GetMouseButtonDown(1))
        {
            int anti = QualitySettings.antiAliasing;
            switch (anti)
            {
                case 2: QualitySettings.antiAliasing = 4; break;
                case 4: QualitySettings.antiAliasing = 8; break;
                case 8: QualitySettings.antiAliasing = 2; break;
            }
        }
    }
}
