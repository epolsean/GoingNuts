using UnityEngine;
using System.Collections;

public class ZoneFinish : MonoBehaviour {

	private int acornsCollected;
	public int acornsRequired = 0;
	private bool zoneFinished = false;
	public SpawnPoints spawnPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(acornsCollected == acornsRequired && !zoneFinished)
		{
			zoneFinished = true;
			finishZone();	//does nothing right now
		}
	}
	public void incrementCount()
	{
		acornsCollected++;
	}

	// This doesn't do anything atm.
	// Not sure what we want to do when we collect the required amount of acorns.
	private void finishZone()
	{
		spawnPoint.incrementSpawn (); // not sure if we want to move the spawn point upon getting the required amount of acorns or not.
		print (spawnPoint.currentSpawnPoint); 
		print ("This zone is finished!");
	}
}
