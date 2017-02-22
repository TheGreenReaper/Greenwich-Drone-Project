using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanObject : MonoBehaviour
{
    Material mat;
    Color color;
    float t;
    int time;
    bool notificationShown = false;
    public GameObject notificationsPlane;
    public GameObject actualBuilding;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Notification());

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.color = color;


    }
    void Fade()
    {
       
    }
    IEnumerator Notification()
    {
        gameObject.tag = "Untagged";
        notificationsPlane.SetActive(true);
        notificationsPlane.GetComponent<Text>().text = "Loading" + "\n" + "(33%)";
        yield return new WaitForSeconds(1);
        notificationsPlane.GetComponent<Text>().text = "Loading" + "\n" + "(66%)"; 
        yield return new WaitForSeconds(1);
        notificationsPlane.GetComponent<Text>().text = "Loading" + "\n" + "(99%)";
        yield return new WaitForSeconds(1);
        notificationsPlane.GetComponent<Text>().text = gameObject.name + "\n" + " discovered";
        GetComponent<AudioSource>().enabled = true;
        notificationShown = true; 
        actualBuilding.SetActive(true);
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(3);
        notificationsPlane.SetActive(false);
        Destroy(gameObject);
    }
}
