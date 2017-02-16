using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public bool isFPS;
    float deltaTime = 0.0f;
    float timeplayed;
    void Start()
    {
        //Application.targetFrameRate = 45;
    }
    void Update()
    {
        if (isFPS == true)
        {
            timeplayed += Time.deltaTime;
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        }
        else
        {
            GetComponent<Text>().text = System.DateTime.Now.ToString();
        }
    }

    void OnGUI()
    {
        if (isFPS == true)
        {
            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(0, 0, w, h * 2 / 100);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = h * 2 / 100;
            style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
            float msec = deltaTime * 1000.0f;
            float fps = 1.0f / deltaTime;
            GetComponent<Text>().text = "FPS: " + fps.ToString("F0") + "\n" + "Time played: " + "\n" + timeplayed.ToString("F0") + " seconds";//string.Format(" ({1:0.} fps) {0:0.0} ms", msec, fps);

        }
    }
}