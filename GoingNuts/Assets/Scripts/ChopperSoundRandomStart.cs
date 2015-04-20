using UnityEngine;
using System.Collections;

public class ChopperSoundRandomStart : MonoBehaviour {
	private float randNum; 
	private float currentTime;
	private bool played = false;
	// Use this for initialization
	void Start () 
	{

		randNum = Random.Range(0F, 10.0F)/10;
		currentTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time >= currentTime + randNum && played == false)
		{
			played = true;
			audio.Play();
		}
	
	}
}
