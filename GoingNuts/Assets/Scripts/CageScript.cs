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
    bool onlyOnce;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (oldPos != transform.position)
        {
            oldPos = transform.position;
        }
        else if(onlyOnce == false)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            endPos = transform.localPosition;
            startTime = Time.time;
            landed = true;
            onlyOnce = true;
        }
        if (landed && !captured)
        {
            reset = true;
            float fracTime = (Time.time - startTime)/4;
            transform.localPosition = Vector3.Lerp(endPos, new Vector3(endPos.x, 10, endPos.z), fracTime);
            if (transform.localPosition.y >= 9.99f && transform.localPosition.y < 10.01f)
            {
                Animator anim = Chopper.GetComponent<Animator>();
                anim.SetBool("CageDropped", false);
                EnemyZone.GetComponent<QuadEnemyScript>().Resume();
                reset = false;
                landed = false;
                onlyOnce = false;
            }
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
