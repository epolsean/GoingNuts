using UnityEngine;
using System.Collections;

public class enemyRotate : MonoBehaviour {

	public GameObject WarningText;
	public GameObject rotatePoint;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(rotatePoint.transform.position, rotatePoint.transform.up, 10 * Time.deltaTime);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			WarningText.SetActive(true);
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			WarningText.SetActive(false);
		}
	}
}
