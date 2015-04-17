using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {

    public GameObject spawnPoint;
    public GameObject Joint1;
    public GameObject Joint2;
    public GameObject Cage;
    public GameObject Chopper;
    public Image screenFade1;
    public Image screenFade2;

    public GameObject player;
    public float startTime;
	public bool beginFade = false;
    public bool stopFade = false;

    float fadeSpeed = 1;

    void Start ()
    {
        screenFade1.enabled = false;
        screenFade2.enabled = false;
    }
	
	// Update is called once per frame
	void Update () 
	{
		if(beginFade && Time.time - startTime >= 1)
		{
			FadeToClear();
		}
        if ((screenFade1.color.a <= .7 || screenFade2.color.a <= .7) && (screenFade1.color.a > .4 || screenFade2.color.a > .4))
        {
            fadeSpeed = 2;
        }
        else if ((screenFade1.color.a <= .4 || screenFade2.color.a <= .4) && (screenFade1.color.a > .1 || screenFade2.color.a > .1))
        {
            fadeSpeed = 3;
        }
        else if (screenFade1.color.a <= .1 || screenFade2.color.a <= .1) 
		{
            screenFade1.enabled = false;
            screenFade1.color = Color.black;
            screenFade2.enabled = false;
            screenFade2.color = Color.black;
            player.gameObject.GetComponent<CharacterController>().enabled = true;
            fadeSpeed = 1;
            beginFade = false;
		}
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerStats>().isSafe == false)
        {
            Animator anim = Chopper.GetComponent<Animator>();
            anim.SetBool("CageDropped", true);
            Joint1.GetComponent<enemyRotate>().playerFound = true;
            Joint2.GetComponent<enemyRotate>().playerFound = true;
            Cage.GetComponent<Rigidbody>().useGravity = true;
            /*
            player = other.gameObject;
            player.GetComponent<PlayerStats>().totalDeaths += 1;
            player.transform.position = spawnPoint.transform.position;
            player.transform.rotation = spawnPoint.transform.rotation;
            player.GetComponent<CharacterController>().enabled = false;
            startTime = Time.time;
            screenFade1.enabled = true;
            screenFade2.enabled = true;
			beginFade = true;
            */
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerStats>().isSafe == false)
        {
            Animator anim = Chopper.GetComponent<Animator>();
            anim.SetBool("CageDropped", true);
            Joint1.GetComponent<enemyRotate>().playerFound = true;
            Joint2.GetComponent<enemyRotate>().playerFound = true;
            //Cage.GetComponent<Rigidbody>().useGravity = true;
            /*
            player = other.gameObject;
            player.GetComponent<PlayerStats>().totalDeaths += 1;
            player.transform.position = spawnPoint.transform.position;
            player.transform.rotation = spawnPoint.transform.rotation;
            player.GetComponent<CharacterController>().enabled = false;
            startTime = Time.time;
            screenFade1.enabled = true;
            screenFade2.enabled = true;
			beginFade = true;
            */
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && Joint1.GetComponent<enemyRotate>().playerFound == true && Joint2.GetComponent<enemyRotate>().playerFound == true)
        {
            //Joint1.GetComponent<enemyRotate>().playerFound = false;
            //Joint2.GetComponent<enemyRotate>().playerFound = false;
        }
    }

    void FadeToClear ()
    {
        // Lerp the colour of the texture between itself and transparent.
        screenFade1.color = Color.Lerp(screenFade1.color, Color.clear, fadeSpeed * Time.fixedDeltaTime);
        screenFade2.color = Color.Lerp(screenFade2.color, Color.clear, fadeSpeed * Time.fixedDeltaTime);
    }
}