using UnityEngine;
using System.Collections;

public class DestroyThis : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider col)
	{
		if(collider.gameObject.tag != "Terrain" && collider.gameObject.tag != "Player")
		{
			Destroy(gameObject);
		}
	}
}
