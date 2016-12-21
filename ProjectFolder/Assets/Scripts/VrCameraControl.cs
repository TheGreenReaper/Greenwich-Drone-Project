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
            transform.Translate(camera.forward);
        }
        input1.text = "Mouse X: " + Input.GetAxis("Mouse X").ToString("F1") + "\n " +
            "Mouse Y: " + Input.GetAxis("Mouse X").ToString("F1");





        //if (Input.GetAxis("6") != 0)
        //{
        //    SetMat();
        //}
        //if (Input.GetAxis("Mouse Y") != null)
        //{
        //    SetMat();
        //}
    }
    void SetMat()
    {
        if (RenderSettings.skybox.name == mat1.name)
        {
            RenderSettings.skybox = mat2;
        }
        else
        {
            RenderSettings.skybox = mat1;
        }
    }
}
