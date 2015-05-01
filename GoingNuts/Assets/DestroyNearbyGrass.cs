using UnityEngine;
using System.Collections;

public class DestroyNearbyGrass : MonoBehaviour {

	public float radius;
	public int grassCount;

	// Use this for initialization
	void Start () {
		GameObject[] grass = GameObject.FindGameObjectsWithTag ("Grass");

		grassCount = grass.Length;

		for(int x = 0; x < grass.Length; x++)
		{
			if(Vector3.Magnitude(grass[x].transform.position - transform.position) <= radius)
			{
				Destroy (grass[x]);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
