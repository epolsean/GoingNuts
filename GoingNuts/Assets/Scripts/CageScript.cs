using UnityEngine;
using System.Collections;

public class CageScript : MonoBehaviour {

    public GameObject Chopper;
    public GameObject EnemyZone;

    Vector3 oldPos = new Vector3(0,0,0);
    Vector3 startPos;
    Vector3 endPos;
    float startTime;
    bool landed;
    bool captured;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (oldPos != transform.position)
        {
            oldPos = transform.position;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            endPos = transform.position;
            startTime = Time.time;
            landed = true;
        }
        if (landed && !captured)
        {
            float fracTime = (Time.time - startTime) / 10;
            transform.position = Vector3.Lerp(endPos, startPos, fracTime);
        }
	}

    void OnTriggerEnter()
    {
        /*
        player = other.gameObject;
        player.GetComponent<PlayerStats>().totalDeaths += 1;
        player.transform.position = spawnPoint.transform.position;
        player.transform.rotation = spawnPoint.transform.rotation;
        player.GetComponent<CharacterController>().enabled = false;
        startTime = Time.time;
        screenFade1.enabled = true;
        screenFade2.enabled = true;
		beginFade = true;
        */
    }
}
