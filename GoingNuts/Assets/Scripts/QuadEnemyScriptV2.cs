using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuadEnemyScriptV2 : MonoBehaviour {

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
    float randomStart;

    void Start ()
    {
        screenFade1.enabled = false;
        screenFade2.enabled = false;
        randomStart = Random.Range(0.0f, 5.0f) + Time.time;
    }
	
	// Update is called once per frame
	void Update () 
	{
        if (Time.time - randomStart >= 0 && Time.time - randomStart < .1f)
        {
            Animator anim = Chopper.GetComponent<Animator>();
            anim.Play(0);
        }
        resetting = Cage.GetComponent<CageScriptV2>().reset;
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
            Cage.GetComponent<CageScriptV2>().captured = false;
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
            if (gameObject.tag == "MazeChopper")
                gameObject.GetComponent<enemyPatrol>().playerFound = true;
            else
            {
                Joint1.GetComponent<enemyRotate>().playerFound = true;
                Joint2.GetComponent<enemyRotate>().playerFound = true;
            }
            Cage.GetComponent<CageScriptV2>().fixedHeight = false;
			Cage.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerStats>().isSafe == false && resetting == false)
        {
            Animator anim = Chopper.GetComponent<Animator>();
            anim.SetBool("CageDropped", true);
            if (gameObject.tag == "MazeChopper")
                gameObject.GetComponent<enemyPatrol>().playerFound = true;
            else
            {
                Joint1.GetComponent<enemyRotate>().playerFound = true;
                Joint2.GetComponent<enemyRotate>().playerFound = true;
            }
            Cage.GetComponent<CageScriptV2>().fixedHeight = false;
			Cage.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    public void Resume()
    {
        if (gameObject.tag == "MazeChopper")
            gameObject.GetComponent<enemyPatrol>().playerFound = false;
		else
        {
            Joint1.GetComponent<enemyRotate>().playerFound = false;
            Joint2.GetComponent<enemyRotate>().playerFound = false;
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