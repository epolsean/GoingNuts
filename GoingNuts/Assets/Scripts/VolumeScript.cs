using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        AudioListener.volume = this.GetComponent<Slider>().value;
	}
}
