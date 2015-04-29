using UnityEngine;
using System.Collections;

public class GrassTestScript : MonoBehaviour 
{
	public GameObject cutGrass;
	public GameObject loneGrass;
	public GameObject bigGrass;

	public int cutChance = 80;
	public int loneChance = 10;
	public int bigChance = 5;
	public int blankSpace = 5;

	//Instantiate(Object original, Vector3 position, Quaternion rotation);
	// Use this for initialization
	void Start () 
	{
		float areaSizeX = transform.localScale.x;
		float areaSizeZ = transform.localScale.z;

		//Quaternion rotation = transform.Rotate (0, 0, 0);

		for(int x = 0; x < areaSizeX * 2; x++)
		{
			for(int z = 0; z < areaSizeZ * 2; z++)
			{
				float randNum = Random.Range(0F, 100F);
				 
				// cut grass chance
				if(randNum <= cutChance)
				{
					Instantiate(cutGrass, new Vector3 (transform.position.x + x/4 - areaSizeX/2, 0, transform.position.z + z/4 - areaSizeZ/2), Quaternion.identity);
					print (1);
				}
				// lone grass chance
				else if(randNum > cutChance && randNum <= cutChance + loneChance)
				{
					Instantiate(loneGrass, new Vector3 (transform.position.x + x/4 - areaSizeX/2, 0, transform.position.z + z/4 - areaSizeZ/2), Quaternion.identity);
					print (2);
				}
				else if(randNum > cutChance + loneChance && randNum <= 100 - bigChance)
				{
					Instantiate(bigGrass, new Vector3 (transform.position.x + x/4 - areaSizeX/2, 0, transform.position.z + z/4 - areaSizeZ/2), Quaternion.identity);
					print (3);
				}//else blank
			}
		}


		/*float randNum = Random.Range(0F, 360F);
		transform.Rotate(0, randNum, 0);*/


	}

}
