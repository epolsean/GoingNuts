using UnityEngine;
using System.Collections;

public class enemyRotate : MonoBehaviour {

	public GameObject rotatePoint;
	public int speed;
    public bool playerFound;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!playerFound)
        {
            transform.RotateAround(rotatePoint.transform.position, rotatePoint.transform.up, speed * Time.deltaTime);
        }
	}
}
