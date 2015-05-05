using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (AudioListener.volume != this.GetComponent<Slider>().value)
        {
            AudioListener.volume = this.GetComponent<Slider>().value;
        }
	}
}
