using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewScript : MonoBehaviour
{
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("view_mode") == 1)
            this.GetComponent<Text>().text = "Current View - Oculus";
        else
            this.GetComponent<Text>().text = "Current View - Standard";
	}
}
