using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanObject : MonoBehaviour
{
    Material mat;
    Color color;
    float timer;
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
        print(timer);
        GetComponent<Renderer>().material.color = color;
        if (notificationsPlane.activeInHierarchy == true && timer <= 10)
        {
            timer += Time.deltaTime * 4;
            notificationsPlane.GetComponent<Text>().text = "Loading" + "\n" + "(" + (timer * 10).ToString("F0") + "%)";
        }

    }
    void Fade()
    {
       
    }
    IEnumerator Notification()
    {
        timer = 0;
        gameObject.tag = "Untagged";
        notificationsPlane.SetActive(true);      
        yield return new WaitForSeconds(3);
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
