using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanningObject : MonoBehaviour {
    Material originalMaterial;
    public Material scanningMaterial;
    public float scanDuration;
    float scale;
    float t = 0.0f;
    bool turnedOn = false;
    public string key;
	// Use this for initialization
	void Start () {
        originalMaterial = GetComponent<Renderer>().material;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("FireLeft"))
        {
            StartCoroutine(Scanning());
        }
        if (turnedOn == true)
        {
            t += 0.5f * Time.deltaTime;
            scale = Mathf.Lerp(0, 40, t);
            GetComponent<Renderer>().material.SetFloat("_RangeScale", scale);
            print(scale);
        }
	}
    IEnumerator Scanning()
    {
        GetComponent<Renderer>().material = scanningMaterial;
        GetComponent<Renderer>().material.SetFloat("_RangeScale", 0);
        GetComponent<Renderer>().material.SetFloat("_Speed", 0);
        turnedOn = true;
        GetComponent<Renderer>().material.SetFloat("_Speed", 0.75f);
        


        yield return new WaitForSeconds(scanDuration);
        turnedOn = true;
        GetComponent<Renderer>().material.SetFloat("_RangeScale", 0);
        GetComponent<Renderer>().material = originalMaterial;
    }
}
