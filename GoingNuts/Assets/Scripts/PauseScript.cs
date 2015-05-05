using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

    public GameObject PauseGroup1;
    public GameObject MyCanvas1;
    public GameObject PauseGroup2;
    public GameObject MyCanvas2;

	// Use this for initialization
    void Start()
    {
        PauseGroup1.SetActive(false);
        PauseGroup2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (MyCanvas1.activeInHierarchy)
            {
                if (PauseGroup1.activeInHierarchy)
                {
                    Time.timeScale = 1;
                    PauseGroup1.SetActive(false);
                }
                else
                {
                    Time.timeScale = 0;
                    PauseGroup1.SetActive(true);
                    MyCanvas1.GetComponent<GoToScript>().pause();
                }
            }
            else if (MyCanvas2.activeInHierarchy)
            {
                if (PauseGroup2.activeInHierarchy)
                {
                    Time.timeScale = 1;
                    PauseGroup2.SetActive(false);
                }
                else
                {
                    Time.timeScale = 0;
                    PauseGroup2.SetActive(true);
                    MyCanvas2.GetComponent<GoToScript>().pause();
                }
            }
        }
	}

    public void Resume()
    {
        if (MyCanvas1.activeInHierarchy)
        {
            Time.timeScale = 1;
            PauseGroup1.SetActive(false);
        }
        else if (MyCanvas2.activeInHierarchy)
        {
            Time.timeScale = 1;
            PauseGroup2.SetActive(false);
        }
    }
}
