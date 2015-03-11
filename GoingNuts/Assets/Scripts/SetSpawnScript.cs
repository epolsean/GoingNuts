using UnityEngine;
using System.Collections;

public class SetSpawnScript : MonoBehaviour
{
    public GameObject currentSpawn;
    public GameObject spawnPoint;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            currentSpawn.transform.position = spawnPoint.transform.position;
            currentSpawn.transform.rotation = spawnPoint.transform.rotation;
        }
    }
}
