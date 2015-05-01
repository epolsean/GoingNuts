using UnityEngine;
using System.Collections;

public class GrassTestScript : MonoBehaviour 
{
	public GameObject cutGrass;
	public GameObject loneGrass;
	public GameObject bigGrass;
	
	// These should add up to 100
	// blankSpace doesn't actually matter, it's chance is based on whatever is leftover from the other 3
	public float cutChance = 80;
	public float loneChance = 10;
	public float bigChance = 5;
	public float blankSpace;
	
	// This is the terrain that you want the grass to conform to
	public Terrain terrain;
	
	
	
	// Use this for initialization
	void Start () 
	{
		blankSpace = 100 - cutChance - loneChance - bigChance;
		// Using the localScale to get the size of the cube area of the grass zone
		float areaSizeX = transform.localScale.x;
		float areaSizeZ = transform.localScale.z;
		
		// Will contain the position of each grass object
		Vector3 grassVector = new Vector3 (0, 0, 0);
		
		// Create as GameObject for parenting
		GameObject grass;
		
		
		for(float x = 0; x < areaSizeX * 2; x++)
		{
			for(float z = 0; z < areaSizeZ * 2; z++)
			{
				float randNum = Random.Range(0F, 100F); // For calculating chance for each type of grass
				Quaternion randomRotation = Quaternion.Euler (0, Random.Range(0F, 360F), 0); // For creating random rotations
				
				// cut grass chance
				if(randNum <= cutChance)
				{
					// The x and z positions for the grass
					grassVector.x = transform.position.x + x/2 - areaSizeX/2;
					grassVector.z = transform.position.z + z/2 - areaSizeZ/2;
					
					// Uses Terrain.SampleHeight to approximate the y location for the grass
					grassVector.y = terrain.SampleHeight (grassVector) + terrain.GetPosition().y;
					
					// Instantiates the grass as a gameObject
					grass = Instantiate(cutGrass, grassVector, randomRotation) as GameObject;
					
					// Sets the parent to be the object this script is attached to
					grass.transform.SetParent(this.transform, true);
				}
				// lone grass chance
				else if(randNum > cutChance && randNum <= cutChance + loneChance)
				{
					// The x and z positions for the grass
					grassVector.x = transform.position.x + x/2 - areaSizeX/2;
					grassVector.z = transform.position.z + z/2 - areaSizeZ/2;
					
					// Uses Terrain.SampleHeight to approximate the y location for the grass
					grassVector.y = terrain.SampleHeight (grassVector) + terrain.GetPosition().y;
					
					// Instantiates the grass as a gameObject
					grass = Instantiate(loneGrass, grassVector, randomRotation) as GameObject;
					
					// Sets the parent to be the object this script is attached to
					grass.transform.SetParent(this.transform, true);
				}
				else if(randNum > cutChance + loneChance && randNum <= 100 - blankSpace)
				{
					// The x and z positions for the grass
					grassVector.x = transform.position.x + x/2 - areaSizeX/2;
					grassVector.z = transform.position.z + z/2 - areaSizeZ/2;
					
					// Uses Terrain.SampleHeight to approximate the y location for the grass
					grassVector.y = terrain.SampleHeight (grassVector) + terrain.GetPosition().y;
					
					// Instantiates the grass as a gameObject
					grass = Instantiate(bigGrass, grassVector, randomRotation) as GameObject;
					
					// Sets the parent to be the object this script is attached to
					grass.transform.SetParent(this.transform, true);
				}//else blank
			}
		}		
	}
}
