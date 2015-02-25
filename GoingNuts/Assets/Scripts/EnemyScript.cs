using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public GameObject spawnPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = spawnPoint.transform.position;
            other.gameObject.transform.rotation = spawnPoint.transform.rotation;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = spawnPoint.transform.position;
            other.gameObject.transform.rotation = spawnPoint.transform.rotation;
        }
    }
}
