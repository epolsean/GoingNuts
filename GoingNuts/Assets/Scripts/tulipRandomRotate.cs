using UnityEngine;
using System.Collections;

public class tulipRandomRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float randNum = Random.Range(0F, 360F);
		transform.Rotate(0, randNum, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
