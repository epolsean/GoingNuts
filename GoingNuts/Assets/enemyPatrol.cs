using UnityEngine;
using System.Collections;

public class enemyPatrol : MonoBehaviour {

	public Transform[] patrol;
	private int Currentpoint;
	public float moveSpeed;
	public float rotateSpeed = 2.0f;
	private bool rotating;
	
	// Use this for initialization
	void Start () 
	{
		transform.position = patrol[0].position;
		Currentpoint = 0;
	}
	
	void Update() 
	{
		if(transform.position == patrol[Currentpoint].position)
		{
			Currentpoint++;
		}
		
		if(Currentpoint >= patrol.Length)
		{
			Currentpoint = 0;
		}
		
		transform.position = Vector3.MoveTowards (transform.position, patrol [Currentpoint].position, moveSpeed * Time.deltaTime);  
		StartCoroutine(TurnTowards(-transform.forward));
	}
	
	IEnumerator TurnTowards(Vector3 lookAtTarget) 
	{    
		
		if(rotating == false) 
		{
			Quaternion newRotation = Quaternion.LookRotation(lookAtTarget - transform.position);
			newRotation.x = 0;
			newRotation.z = 0;
			
			for (float u = 0.0f; u <= 1.0f; u += Time.deltaTime * rotateSpeed) 
			{
				rotating = true;
				transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, u);
				
				yield return null;
			}
			rotating = false;
		}
	}
}