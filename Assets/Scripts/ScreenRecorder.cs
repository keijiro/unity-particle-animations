using UnityEngine;
using System.Collections;

public class ScreenRecorder : MonoBehaviour
{
    public int superSize;
    public bool recordFromStart;
    int frameCount;
    bool recording;

    void StartRecording ()
    {
        System.IO.Directory.CreateDirectory ("Capture");

        Time.captureFramerate = 60;
        frameCount = -1;
        recording = true;

        Debug.Log ("Click Game View to stop recording.");
    }

    void Start ()
    {
        if (recordFromStart)
            StartRecording ();
    }
            
    void Update ()
    {
        if (recording)
        {
            if (Input.GetMouseButtonDown (0))
            {
                recording = false;
                enabled = false;
            }
            else
            {
                if (frameCount > 0)
                {
                    var name = "Capture/frame" + frameCount.ToString ("0000") + ".png";
                    Application.CaptureScreenshot (name, superSize);
                }

                frameCount++;

                if (frameCount > 0 && frameCount % 60 == 0)
                    Debug.Log ((frameCount / 60).ToString () + " seconds elapsed.");
            }
        }
    }

    void OnGUI ()
    {
        if (!recording && GUI.Button (new Rect (0, 0, 200, 50), "Start Recording"))
        {
            StartRecording ();
        }
    }
}
