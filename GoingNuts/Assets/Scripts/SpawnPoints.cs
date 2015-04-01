using UnityEngine;
using System.Collections;

public class SpawnPoints : MonoBehaviour {

	public int currentSpawnPoint = 1;
	public GameObject[] spawnPoints; // [0] is currentSpawnPoint, [1] and above is spawn point number in order

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void incrementSpawn()
	{
		currentSpawnPoint++;
		spawnPoints [0].transform.position = spawnPoints [currentSpawnPoint].transform.position;
		spawnPoints [0].transform.rotation = spawnPoints [currentSpawnPoint].transform.rotation;
	}
}
