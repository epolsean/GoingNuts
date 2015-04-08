using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {

    public Transform[] points;
    private int Currentpoint;
    public float moveSpeed;
    float startMove;
    float startTime;
    GameObject acorn;
	private bool destroyThis = false;

    void Start()
    {
        startTime = Time.time;
        startMove = Random.Range(0, 3);
        Currentpoint = 0;

        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "Acorn")
            {
                acorn = child.gameObject;
            }
        }
    }

    void Update()
    {
        if (Time.time - startTime >= startMove)
        {
            if (Mathf.Abs(acorn.transform.position.y - points[Currentpoint].position.y) <= .01)
            {
                Currentpoint++;
            }

            if (Currentpoint >= points.Length)
            {
                Currentpoint = 0;
            }

            acorn.transform.position = Vector3.MoveTowards(acorn.transform.position, points[Currentpoint].position, moveSpeed * Time.deltaTime);
        }

		if(destroyThis && !audio.isPlaying)
	    {
			Destroy(this.gameObject);
		}
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
			audio.Play();
			other.gameObject.GetComponent<PlayerStats>().totalPickups++;
			acorn.GetComponentInChildren<MeshRenderer>().enabled = false;
			destroyThis = true;
        }
    }
}
