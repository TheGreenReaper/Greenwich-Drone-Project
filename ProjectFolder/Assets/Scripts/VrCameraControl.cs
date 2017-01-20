using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VrCameraControl : MonoBehaviour
{
    public Transform camera;
    public Material mat1;
    public Material mat2;
    public Text input1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Translate(Camera.main.transform.forward);
        }






        //if (Input.GetAxis("6") != 0)
        //{
        //    SetMat();
        //}
        //if (Input.GetAxis("Mouse Y") != null)
        //{
        //    SetMat();
        //}
    }

}
