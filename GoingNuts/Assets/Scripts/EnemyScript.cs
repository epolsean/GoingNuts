using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {

    public GameObject spawnPoint;
    public Image screenFade1;
    public Image screenFade2;

    GameObject player;
    float fadeSpeed = 1;
    float startTime;
	private bool beginFade = false;
	private bool stopFade = false;

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
            player = other.gameObject;
            player.transform.position = spawnPoint.transform.position;
            player.transform.rotation = spawnPoint.transform.rotation;
            player.GetComponent<CharacterController>().enabled = false;
            startTime = Time.time;
            screenFade1.enabled = true;
            screenFade2.enabled = true;
			beginFade = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" &&other.gameObject.GetComponent<PlayerStats>().isSafe == false)
        {
            player = other.gameObject;
            player.transform.position = spawnPoint.transform.position;
            player.transform.rotation = spawnPoint.transform.rotation;
            player.GetComponent<CharacterController>().enabled = false;
            startTime = Time.time;
            screenFade1.enabled = true;
            screenFade2.enabled = true;
			beginFade = true;
        }
    }

    void FadeToClear ()
    {
        // Lerp the colour of the texture between itself and transparent.
        screenFade1.color = Color.Lerp(screenFade1.color, Color.clear, fadeSpeed * Time.fixedDeltaTime);
        screenFade2.color = Color.Lerp(screenFade2.color, Color.clear, fadeSpeed * Time.fixedDeltaTime);
    }
}