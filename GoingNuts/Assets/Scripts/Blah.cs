using UnityEngine;
using System.Collections;

public class Blah : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] Acorns = GameObject.FindGameObjectsWithTag("Pickup");
        foreach (GameObject acorn in Acorns)
        {
            acorn.gameObject.transform.position = new Vector3(-39.21728f, 5.456894f, -5.317715f);
        }
        print("Acorns: " + Acorns.Length);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
