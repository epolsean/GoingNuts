using UnityEngine;
using System.Collections;

public class EnemyMoveScript : MonoBehaviour {

	public int speed;
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(new Vector3(0,0,-5), Vector3.up, speed * Time.deltaTime);
	}
}
