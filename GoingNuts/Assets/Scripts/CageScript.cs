using UnityEngine;
using System.Collections;

public class CageScript : MonoBehaviour {

    public GameObject Chopper;
    public GameObject EnemyZone;
    public bool captured;
    public bool landed;
    public bool reset;
	public bool canMove = true;

    Vector3 oldPos = new Vector3(0,0,0);
    Vector3 startPos;
    Vector3 endPos;
    float startTime;
    public bool onlyOnce;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (oldPos != transform.position)
        {
            oldPos = transform.position;
        }
		// if stopped, and cage landed
        /*else if(onlyOnce == false)
        {
            endPos = transform.localPosition;
            onlyOnce = true;
        }*/

		if(oldPos.y != transform.position.y && landed == false) //
		{
			landed = true;
			gameObject.GetComponent<Rigidbody>().useGravity = false; //
			startPos.y = transform.localPosition.y;
			startTime = Time.time;
			if(onlyOnce == false)
			{
				endPos = transform.localPosition;
				onlyOnce = true;
			}
		}
        if (landed && !captured)
        {
			startPos.x = endPos.x;
			startPos.z = endPos.z;

            reset = true;

            float fracTime = (Time.time - startTime)/4;

			transform.localPosition = Vector3.Lerp(startPos, new Vector3(endPos.x, 10, endPos.z), fracTime);

            if (transform.localPosition.y >= 9.99f && transform.localPosition.y < 10.01f)
            {
                Animator anim = Chopper.GetComponent<Animator>();
                anim.SetBool("CageDropped", false);
                EnemyZone.GetComponent<QuadEnemyScript>().Resume();
                reset = false;
                onlyOnce = false;
				landed = false;
            }
        }
		if (transform.localPosition.y >= 9.99f && transform.localPosition.y < 10.01f)
		{
			canMove = true;
			EnemyZone.GetComponent<QuadEnemyScript>().Resume();
			onlyOnce = false;
		}
		else
		{
			canMove = false;
		}
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            captured = true;
            GameObject player = other.gameObject;
            player.GetComponent<PlayerStats>().totalDeaths += 1;
            player.GetComponent<CharacterController>().enabled = false;
            EnemyZone.GetComponent<QuadEnemyScript>().startTime = Time.time;
            EnemyZone.GetComponent<QuadEnemyScript>().player = other.gameObject;
            EnemyZone.GetComponent<QuadEnemyScript>().screenFade1.color = Color.clear;
            EnemyZone.GetComponent<QuadEnemyScript>().screenFade2.color = Color.clear;
            EnemyZone.GetComponent<QuadEnemyScript>().screenFade1.enabled = true;
            EnemyZone.GetComponent<QuadEnemyScript>().screenFade2.enabled = true;
            EnemyZone.GetComponent<QuadEnemyScript>().beginFade2 = true;
        }
    }
}
