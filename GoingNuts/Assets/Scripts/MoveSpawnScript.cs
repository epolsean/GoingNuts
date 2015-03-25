using UnityEngine;
using System.Collections;

public class MoveSpawnScript : MonoBehaviour {

    public Transform[] SpawnPoints;
    public int CurrentSpawnPoint;
    public int setSpawn;

	// Use this for initialization
	void Start () {
        if(CurrentSpawnPoint < SpawnPoints.Length || CurrentSpawnPoint >= 0)
        {
            this.gameObject.transform.position = SpawnPoints[CurrentSpawnPoint].position;
            this.gameObject.transform.rotation = SpawnPoints[CurrentSpawnPoint].rotation;
            setSpawn = CurrentSpawnPoint;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (setSpawn != CurrentSpawnPoint)
        {
            if (CurrentSpawnPoint < SpawnPoints.Length || CurrentSpawnPoint >= 0)
            {
                this.gameObject.transform.position = SpawnPoints[CurrentSpawnPoint].position;
                this.gameObject.transform.rotation = SpawnPoints[CurrentSpawnPoint].rotation;
                setSpawn = CurrentSpawnPoint;
            }
        }
	}
}
