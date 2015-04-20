using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnableImage : MonoBehaviour {

	private Image image;

	// Use this for initialization
	void Start () {
		GameObject fader = GameObject.Find("Fader");
		image = fader.GetComponent<Image> ();
		image.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
