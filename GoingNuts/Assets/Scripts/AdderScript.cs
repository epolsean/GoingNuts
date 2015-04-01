using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdderScript : MonoBehaviour {

    public Text number;
    int count = 0;
    int i = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        number.text = count.ToString();
        count += 27;
        i++;
	}
}
