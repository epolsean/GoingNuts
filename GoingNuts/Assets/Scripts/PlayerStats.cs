using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public bool isSafe;
    public bool OcCamOn;

    public float totalPickups;
    public float totalTime;
    public float totalDeaths;

    public GameObject PickupText1;
    public GameObject TimerText1;
    public GameObject PickupText2;
    public GameObject TimerText2;
    public GameObject OcCam;
    public GameObject OcCanvas;
    public GameObject NormConvas;
    
    float startTime;
    int seconds;
    int minutes;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (OcCam.activeInHierarchy && OcCamOn == false)
        {
            OcCamOn = true;
            OcCanvas.SetActive(true);
            NormConvas.SetActive(false);
        }
        else if (OcCam.activeInHierarchy == false && OcCamOn)
        {
            OcCamOn = false;
            OcCanvas.SetActive(false);
            NormConvas.SetActive(true);
        }

        if (PickupText1.GetComponent<Text>().text != totalPickups.ToString() || PickupText2.GetComponent<Text>().text != totalPickups.ToString())
        {
            PickupText1.GetComponent<Text>().text = totalPickups.ToString();
            PickupText2.GetComponent<Text>().text = totalPickups.ToString();
        }

        totalTime = Time.time-startTime;
        minutes = (int)totalTime / 60;
        seconds = (int)totalTime % 60;

        if(seconds < 10 && minutes < 10)
        {
            TimerText1.GetComponent<Text>().text = "0" + minutes + ":0" + seconds;
            TimerText2.GetComponent<Text>().text = "0" + minutes + ":0" + seconds;
        }
        else if (seconds >= 10 && minutes < 10)
        {
            TimerText1.GetComponent<Text>().text = "0" + minutes + ":" + seconds;
            TimerText2.GetComponent<Text>().text = "0" + minutes + ":" + seconds;
        }
        else if (seconds < 10 && minutes >= 10)
        {
            TimerText1.GetComponent<Text>().text = minutes + ":0" + seconds;
            TimerText2.GetComponent<Text>().text = minutes + ":0" + seconds;
        }
        else if (seconds >= 10 && minutes >= 10)
        {
            TimerText1.GetComponent<Text>().text = minutes + ":" + seconds;
            TimerText2.GetComponent<Text>().text = minutes + ":" + seconds;
        }
	}
}
