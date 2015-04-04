using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoringScript : MonoBehaviour {

    public GameObject ExitPrompt;
    public GameObject HighscoreAdder;
    public GameObject HighscoreAlert;
    public GameObject HighscoreNamer;
    public GameObject Highscores;

    public Text HighscoreName;
    public Text Number1;
    public Text Number2;
    public Text Number3;
    public Text Number4;

    public bool oneDone;
    public bool twoDone;
    public bool threeDone;
    public bool fourDone;
    bool newHighscore;
    bool scoreAdded;

    float extraTime;
    float finalScore;
    float floatCount;
    float minutes;
    float pickups;
    float startTime;
    float totalTime;

    int intCount;
    int minScore;
    int seconds;

    string name;

    string[] min;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        pickups = PlayerPrefs.GetFloat("Total_Pickups");
        totalTime = PlayerPrefs.GetFloat("Total_Time");
        minutes = totalTime / 60;
        if (minutes < 10)
        {
            extraTime = 10 - minutes;
        }
        finalScore = pickups * 100 + Mathf.Floor(extraTime) * 1000;
	}

    // Update is called once per frame
    void Update()
    {
        if (fourDone == false && Time.time - startTime > .5f)
        {
            Adder();
        }
        if (fourDone && (int)finalScore > minScore && scoreAdded == false)
        {

            if (newHighscore && Time.time - startTime > 1.5f)
            {
                HighscoreAlert.SetActive(false);
                HighscoreNamer.SetActive(true);
            }
            else if (Time.time - startTime > .5f)
            {
                newHighscore = true;
                HighscoreAlert.SetActive(true);
                HighscoreAdder.SetActive(false);
            }
        }
        else if ((int)finalScore < minScore && Time.time - startTime > .5f)
        {
            ExitPrompt.SetActive(true);
            HighscoreAdder.SetActive(false);
        }
    }
	
	void Adder()
    {
        if (oneDone == false && twoDone == false && threeDone == false && fourDone == false)
        {
            Number1.text = intCount.ToString();
            if (pickups - intCount > 100)
            {
                intCount += 33;
            }
            else if (pickups - intCount > 10 && pickups - intCount <= 100)
            {
                intCount += 3;
            }
            else if (pickups - intCount > 0 && pickups - intCount <= 10)
            {
                intCount += 1;
            }
            else
            {
                oneDone = true;
                intCount = 0;
            }
            if ((int)(pickups - intCount) == 1)
            {
                intCount = (int)pickups;
            }
        }
        else if (oneDone == true && twoDone == false && threeDone == false && fourDone == false)
        {
            minutes = intCount / 60;
            seconds = intCount % 60;

            if (seconds < 10 && minutes < 10)
            {
                Number2.text = "0" + minutes + ":0" + seconds;
            }
            else if (seconds >= 10 && minutes < 10)
            {
                Number2.text = "0" + minutes + ":" + seconds;
            }
            else if (seconds < 10 && minutes >= 10)
            {
                Number2.text = minutes + ":0" + seconds;
            }
            else if (seconds >= 10 && minutes >= 10)
            {
                Number2.text = minutes + ":" + seconds;
            }

            if (totalTime - intCount > 100)
            {
                intCount += 33;
            }
            else if (totalTime - intCount > 10 && totalTime - intCount <= 100)
            {
                intCount += 3;
            }
            else if (totalTime - intCount >= -1 && totalTime - intCount <= 10)
            {
                intCount += 1;
            }

            if (totalTime - intCount <= -1)
            {
                twoDone = true;
                intCount = 0;
            }
        }
        else if (oneDone == true && twoDone == true && threeDone == false && fourDone == false)
        {
            Number3.text = (Mathf.Floor(floatCount)).ToString();
            if (extraTime - floatCount > 100)
            {
                floatCount += 3.3f;
            }
            else if (extraTime - floatCount > 10 && extraTime - floatCount <= 100)
            {
                floatCount += .3f;
            }
            else if (extraTime - floatCount > 0 && extraTime - floatCount <= 10)
            {
                floatCount += .1f;
            }
            else
            {
                threeDone = true;
                floatCount = 0;
            }
            if ((int)(extraTime - floatCount) == 1)
            {
                floatCount = (int)extraTime;
            }
        }
        else if (oneDone == true && twoDone == true && threeDone == true && fourDone == false)
        {
            Number4.text = intCount.ToString();
            if (finalScore - intCount > 100)
            {
                intCount += 77;
            }
            else if (finalScore - intCount > 10 && finalScore - intCount <= 100)
            {
                intCount += 7;
            }
            else if (finalScore - intCount > 0 && finalScore - intCount <= 10)
            {
                intCount += 1;
            }
            else
            {
                fourDone = true;
                intCount = 0;
                startTime = Time.time;
                min = Highscores.GetComponent<HighscoresScript>().entries[9];
                minScore = int.Parse(min[1]);
            }
            if ((int)(finalScore - intCount) == 1)
            {
                intCount = (int)finalScore;
            }
        }
	}

    public void submitScore()
    {
        name = HighscoreName.text;
        Highscores.GetComponent<HighscoresScript>().AddScore(name,(int)finalScore);
        scoreAdded = true;
        HighscoreNamer.SetActive(false);
        ExitPrompt.SetActive(true);
    }
}
