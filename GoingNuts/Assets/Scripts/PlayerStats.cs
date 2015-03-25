﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public float totalPickups;
    public GameObject PickupText;
    public GameObject TimerText;
    public GameObject OcCam;
    public GameObject OcCanvas;
    public GameObject NormConvas;
    public bool isSafe;
    public bool OcCamOn;
    
    float startTime;
    float totalTime;
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

	    if(PickupText.GetComponent<Text>().text != totalPickups.ToString())
        {
            PickupText.GetComponent<Text>().text = totalPickups.ToString();
        }

        totalTime = Time.time-startTime;
        minutes = (int)totalTime / 60;
        seconds = (int)totalTime % 60;

        if(seconds < 10 && minutes < 10)
        {
            TimerText.GetComponent<Text>().text = "0"+minutes+":0"+seconds;
        }
        else if (seconds > 10 && minutes < 10)
        {
            TimerText.GetComponent<Text>().text = "0" + minutes + ":" + seconds;
        }
        else if (seconds > 10 && minutes > 10)
        {
            TimerText.GetComponent<Text>().text = minutes + ":" + seconds;
        }
	}
}
