using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

    public float totalPickups = 0;
    public float totalTime = 0;
    float totalScore = 0;
    float extraTime = 0;
    float minutes = 0;

	// Use this for initialization
	void Start () {
        minutes = totalTime / 60;
        if(minutes < 10)
        {
            extraTime = 10 - minutes;
        }
        totalScore = totalPickups * 100 + Mathf.Floor(extraTime) * 1000;
        print("Total Time: " + totalTime);
        print("Minutes: " + minutes);
        print("Extra Time: " + extraTime);
        print("Total Score: " + totalScore);
	}
}
