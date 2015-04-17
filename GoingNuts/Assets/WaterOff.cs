using UnityEngine;
using System.Collections;

public class WaterOff : MonoBehaviour {
	public AudioSource water1;
	public AudioSource water2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			water1.volume = 0;
			water2.volume = 0;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			water1.volume = 1;
			water2.volume = 1;
		}
	}
}
