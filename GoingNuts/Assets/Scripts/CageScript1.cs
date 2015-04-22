using UnityEngine;
using System.Collections;

public class CageScript : MonoBehaviour {

    public GameObject Chopper;
    public GameObject EnemyZone;
    public bool captured;
    public bool landed;
    public bool reset;

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
		// if moving update oldPos, or cage dropping
		//if(gameObject.GetComponent<Rigidbody>().useGravity == true)
		//{
			if (oldPos != transform.position/* && Mathf.Abs(transform.position.y - 6) > 0.01f*/)
	        {
	            oldPos = transform.position;
	        }
			// if stopped, and cage landed
	        else if(onlyOnce == false)
	        {
	            //gameObject.GetComponent<Rigidbody>().useGravity = false;
	            endPos = transform.localPosition;
	            //startTime = Time.time;
	            //landed = true;
	            onlyOnce = true;
	        }
		//}

        if (landed && !captured)
        {
			print ("endPos " + endPos.y);
			startPos.x = endPos.x;
			startPos.z = endPos.z;

            reset = true;
			//print("StartTime " + startTime);

            float fracTime = (Time.time - startTime)/4;
			print ("fracTime " + fracTime);
            //transform.localPosition = Vector3.Lerp(endPos, new Vector3(endPos.x, 10, endPos.z), fracTime);
			transform.localPosition = Vector3.Lerp(startPos, new Vector3(endPos.x, 10, endPos.z), fracTime);

			//print ("lerping?");
			//print (transform.localPosition.y);

            if (transform.localPosition.y >= 9.99f && transform.localPosition.y < 10.01f)
            {
                Animator anim = Chopper.GetComponent<Animator>();
                anim.SetBool("CageDropped", false);
                EnemyZone.GetComponent<QuadEnemyScript>().Resume();
                reset = false;
                //landed = false;
                onlyOnce = false;
				landed = false;
            }
        }
		if(oldPos.y != transform.position.y && landed == false) //
		{
			landed = true;
			gameObject.GetComponent<Rigidbody>().useGravity = false; //
			startPos.y = transform.localPosition.y;
			print (startPos.y);
			print ("stuff happened");
			startTime = Time.time;
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
