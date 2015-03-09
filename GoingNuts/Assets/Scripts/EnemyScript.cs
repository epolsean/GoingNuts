using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public GameObject spawnPoint;
	public ScreenFader screenFade1;
	public ScreenFader screenFade2;
	public ScreenFader screenFade3;
	public OVRPlayerController player;

	private bool beginFade = false;
	private bool stopFade = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(beginFade)
		{
			screenFade1.fadeToBlack();
			screenFade2.fadeToBlack();
			screenFade3.fadeToBlack();

			// Stop the player's movement while they are respawning
			// I didn't have a chance to test this with the rift on, so if it causes problems then remove this.
			player.Stop ();
		}
		if (screenFade1.alpha >= .8 && !stopFade) 
		{
			stopFade = true;
		}
		if (stopFade && screenFade1.alpha <= .1) 
		{
			stopFade = false;
			screenFade1.endFade();
			screenFade2.endFade();
			screenFade3.endFade();
			beginFade = false;
		}
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && (this.gameObject.name == "EnemyZone" && other.gameObject.GetComponent<PlayerStats>().isSafe == false))
        {
            other.gameObject.transform.position = spawnPoint.transform.position;
            other.gameObject.transform.rotation = spawnPoint.transform.rotation;

			beginFade = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && (this.gameObject.name == "EnemyZone" && other.gameObject.GetComponent<PlayerStats>().isSafe == false))
        {
            other.gameObject.transform.position = spawnPoint.transform.position;
            other.gameObject.transform.rotation = spawnPoint.transform.rotation;

			beginFade = true;
        }
    }
}
