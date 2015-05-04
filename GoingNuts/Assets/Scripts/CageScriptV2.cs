using UnityEngine;
using System.Collections;

public class CageScriptV2 : MonoBehaviour
{
    public GameObject Chopper;
    public GameObject EnemyZone;
    public Collider CageCollider;
    public bool captured;
    public bool landed;
    public bool reset;
    public bool fixedHeight;

    Vector3 oldPos = new Vector3(0,0,0);
    Vector3 startPos;
    Vector3 endPos;
    float startTime;
    bool onlyOnce;
    bool started;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (started == true)
        {
            if (onlyOnce == false)
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
                float fracTime = (Time.time - startTime) / 3;
                transform.localPosition = Vector3.Lerp(endPos, new Vector3(endPos.x, 10, endPos.z), fracTime);
                if (transform.localPosition.y >= 9.99f)
                {
                    transform.localPosition = new Vector3(0, 10, 0);
                    Animator anim = Chopper.GetComponent<Animator>();
                    anim.SetBool("CageDropped", false);
                    EnemyZone.GetComponent<QuadEnemyScriptV2>().Resume();
                    reset = false;
                    landed = false;
                    onlyOnce = false;
                    started = false;
                }
            }
        }
        if(started == false && fixedHeight == true)
        {
            transform.localPosition = new Vector3(0, 10, 0);
        }
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Terrain")
        {
            started = true;
            fixedHeight = true;
        }
        else
        {
            Physics.IgnoreCollision(col.collider, CageCollider);
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
            EnemyZone.GetComponent<QuadEnemyScriptV2>().startTime = Time.time;
            EnemyZone.GetComponent<QuadEnemyScriptV2>().player = other.gameObject;
            EnemyZone.GetComponent<QuadEnemyScriptV2>().screenFade1.color = Color.clear;
            EnemyZone.GetComponent<QuadEnemyScriptV2>().screenFade2.color = Color.clear;
            EnemyZone.GetComponent<QuadEnemyScriptV2>().screenFade1.enabled = true;
            EnemyZone.GetComponent<QuadEnemyScriptV2>().screenFade2.enabled = true;
            EnemyZone.GetComponent<QuadEnemyScriptV2>().beginFade2 = true;
        }
    }
}
