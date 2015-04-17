using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuadEnemyScript : MonoBehaviour {

    public GameObject spawnPoint;
    public GameObject Joint1;
    public GameObject Joint2;
    public GameObject Cage;
    public GameObject Chopper;
    public Image screenFade1;
    public Image screenFade2;

    public GameObject player;
    public float startTime;
    public bool beginFade1 = false;
    public bool beginFade2 = false;
    public bool stopFade = false;

    public float fadeSpeed = 1;
    bool resetting = false;

    void Start ()
    {
        screenFade1.enabled = false;
        screenFade2.enabled = false;
    }
	
	// Update is called once per frame
	void Update () 
	{
        resetting = Cage.GetComponent<CageScript>().reset;
		if(beginFade1 && Time.time - startTime >= 1)
		{
			FadeToClear();
		}
        if (beginFade1 && (screenFade1.color.a <= .1 || screenFade2.color.a <= .1)) 
		{
            screenFade1.enabled = false;
            screenFade1.color = Color.black;
            screenFade2.enabled = false;
            screenFade2.color = Color.black;
            player.gameObject.GetComponent<CharacterController>().enabled = true;
            fadeSpeed = 5;
            beginFade1 = false;
		}

        if (beginFade2 && Time.time - startTime >= 1)
        {
            FadeToBlack();
        }
        if (beginFade2 && (screenFade1.color.a >= .9 || screenFade2.color.a >= .9))
        {
            screenFade1.color = Color.black;
            screenFade2.color = Color.black;
            fadeSpeed = 5;
            beginFade2 = false;
            player.transform.position = spawnPoint.transform.position;
            player.transform.rotation = spawnPoint.transform.rotation;
            player.GetComponent<CharacterController>().enabled = false;
            Cage.GetComponent<CageScript>().captured = false;
            startTime = Time.time;
            screenFade1.enabled = true;
            screenFade2.enabled = true;
            beginFade1 = true;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerStats>().isSafe == false && resetting == false)
        {
            Animator anim = Chopper.GetComponent<Animator>();
            anim.SetBool("CageDropped", true);
            Joint1.GetComponent<enemyRotate>().playerFound = true;
            Joint2.GetComponent<enemyRotate>().playerFound = true;
            Cage.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerStats>().isSafe == false && resetting == false)
        {
            Animator anim = Chopper.GetComponent<Animator>();
            anim.SetBool("CageDropped", true);
            Joint1.GetComponent<enemyRotate>().playerFound = true;
            Joint2.GetComponent<enemyRotate>().playerFound = true;
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
        float fracTime = (Time.time - startTime) / fadeSpeed;
        screenFade1.color = Color.Lerp(screenFade1.color, Color.clear, fracTime);
        screenFade2.color = Color.Lerp(screenFade2.color, Color.clear, fracTime);
    }

    void FadeToBlack()
    {
        // Lerp the colour of the texture between itself and transparent.
        float fracTime = (Time.time - startTime) / fadeSpeed;
        screenFade1.color = Color.Lerp(screenFade1.color, Color.black, fracTime);
        screenFade2.color = Color.Lerp(screenFade2.color, Color.black, fracTime);
    }
}