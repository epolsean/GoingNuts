using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class AchievementsScript : MonoBehaviour
{
    public GameObject Achievement1;
    public GameObject Achievement2;
    public GameObject Achievement3;
    public GameObject Achievement4;
    public GameObject Achievement5;
    public GameObject Achievement6;
    public GameObject Achievement7;
    public GameObject Achievement8;

    public GameObject Achievement1Lock;
    public GameObject Achievement2Lock;
    public GameObject Achievement3Lock;
    public GameObject Achievement4Lock;
    public GameObject Achievement5Lock;
    public GameObject Achievement6Lock;
    public GameObject Achievement7Lock;
    public GameObject Achievement8Lock;

    public Text AchievementDescription;

    public EventSystem eventSys;

    float pickups;
    float totalTime;
    float deaths;
    int completedGame;
    bool refreshed;

	// Use this for initialization
	void Start () {
        refreshed = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!refreshed)
        {
            CheckAchievements();
            refreshed = true;
        }
        if (Input.anyKey == true || Input.GetMouseButtonDown(0))
        {
            DisplayText();
        }
	}

    public void MouseHover(GameObject highlightedObject)
    {
        if (highlightedObject.gameObject == Achievement1.gameObject)
        {
            AchievementDescription.text = "Complete the game.";
        }
        else if (highlightedObject == Achievement2)
        {
            AchievementDescription.text = "Collect 50 acorns in one game.";
        }
        else if (highlightedObject == Achievement3)
        {
            AchievementDescription.text = "Collect 100 acorns in one game.";
        }
        else if (highlightedObject == Achievement4)
        {
            AchievementDescription.text = "Collect 200 acorns in one game.";
        }
        else if (highlightedObject == Achievement5)
        {
            AchievementDescription.text = "Collect all 300 acorns in one game.";
        }
        else if (highlightedObject == Achievement6)
        {
            AchievementDescription.text = "Complete the game in 3 minutes or less.";
        }
        else if (highlightedObject == Achievement7)
        {
            AchievementDescription.text = "Spend 20 minutes or more in one game.";
        }
        else if (highlightedObject == Achievement8)
        {
            AchievementDescription.text = "Collect 0 acorns, don't die, and complete the game in 3 minutes or less.";
        }
        else if (eventSys.currentSelectedGameObject == null)
        {
            AchievementDescription.text = "";
        }
    }

    void DisplayText()
    {
        if (eventSys.currentSelectedGameObject == Achievement1)
        {
            AchievementDescription.text = "Complete the game.";
        }
        else if (eventSys.currentSelectedGameObject == Achievement2)
        {
            AchievementDescription.text = "Collect 50 acorns in one game.";
        }
        else if (eventSys.currentSelectedGameObject == Achievement3)
        {
            AchievementDescription.text = "Collect 100 acorns in one game.";
        }
        else if (eventSys.currentSelectedGameObject == Achievement4)
        {
            AchievementDescription.text = "Collect 200 acorns in one game.";
        }
        else if (eventSys.currentSelectedGameObject == Achievement5)
        {
            AchievementDescription.text = "Collect all 300 acorns in one game.";
        }
        else if (eventSys.currentSelectedGameObject == Achievement6)
        {
            AchievementDescription.text = "Complete the game in 3 minutes or less.";
        }
        else if (eventSys.currentSelectedGameObject == Achievement7)
        {
            AchievementDescription.text = "Spend 20 minutes or more in one game.";
        }
        else if (eventSys.currentSelectedGameObject == Achievement8)
        {
            AchievementDescription.text = "Collect 0 acorns, don't die, and complete the game in 3 minutes or less.";
        }
        else
        {
            AchievementDescription.text = "";
        }
    }

    public void UpdateAchievements()
    {
        if (PlayerPrefs.GetInt("Complete_Game") == 1)
        {
            Achievement1Lock.SetActive(false);
        }
        if (PlayerPrefs.GetInt("50_Acorns") == 1)
        {
            Achievement2Lock.SetActive(false);
        }
        if (PlayerPrefs.GetInt("100_Acorns") == 1)
        {
            Achievement3Lock.SetActive(false);
        }
        if (PlayerPrefs.GetInt("200_Acorns") == 1)
        {
            Achievement4Lock.SetActive(false);
        }
        if (PlayerPrefs.GetInt("All_Acorns") == 1)
        {
            Achievement5Lock.SetActive(false);
        }
        if (PlayerPrefs.GetInt("3_Minute_Run") == 1)
        {
            Achievement6Lock.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Exploring") == 1)
        {
            Achievement7Lock.SetActive(false);
        }
        if (PlayerPrefs.GetInt("0_Acorn_Run") == 1)
        {
            Achievement8Lock.SetActive(false);
        }
    }

    public void CheckAchievements()
    {
        pickups = PlayerPrefs.GetFloat("Total_Pickups");
        totalTime = PlayerPrefs.GetFloat("Total_Time");
        deaths = PlayerPrefs.GetFloat("Total_Deaths");
        completedGame = PlayerPrefs.GetInt("Game_Won");

        if (pickups >= 50)
        {
            PlayerPrefs.SetInt("50_Acorns", 1);
        }

        if (pickups >= 100)
        {
            PlayerPrefs.SetInt("100_Acorns", 1);
        }

        if (pickups >= 200)
        {
            PlayerPrefs.SetInt("200_Acorns", 1);
        }

        if (pickups == 300)
        {
            PlayerPrefs.SetInt("All_Acorns", 1);
        }

        if (completedGame == 1)
        {
            PlayerPrefs.SetInt("Complete_Game", 1);
        }

        if (pickups == 0 && deaths == 0 && totalTime <= 180 && totalTime != 0)
        {
            PlayerPrefs.SetInt("0_Acorn_Run", 1);
        }

        if (totalTime <= 180 && totalTime != 0)
        {
            PlayerPrefs.SetInt("3_Minute_Run", 1);
        }

        if (totalTime >= 1200)
        {
            PlayerPrefs.SetInt("Exploring", 1);
        }
    }

    public void ResetAchievements()
    {
        PlayerPrefs.SetInt("50_Acorns", 0);
        PlayerPrefs.SetInt("100_Acorns", 0);
        PlayerPrefs.SetInt("200_Acorns", 0);
        PlayerPrefs.SetInt("All_Acorns", 0);
        PlayerPrefs.SetInt("Complete_Game", 0);
        PlayerPrefs.SetInt("0_Acorn_Run", 0);
        PlayerPrefs.SetInt("3_Minute_Run", 0);
        PlayerPrefs.SetInt("Exploring", 0);

        PlayerPrefs.SetFloat("Total_Pickups",0);
        PlayerPrefs.SetFloat("Total_Time",0);
        PlayerPrefs.SetFloat("Total_Deaths",0);
        PlayerPrefs.SetInt("Game_Won",0);

        pickups = 0;
        totalTime = 0;
        deaths = 0;
        completedGame = 0;
        
        Achievement1Lock.SetActive(true);
        Achievement2Lock.SetActive(true);
        Achievement3Lock.SetActive(true);
        Achievement4Lock.SetActive(true);
        Achievement5Lock.SetActive(true);
        Achievement6Lock.SetActive(true);
        Achievement7Lock.SetActive(true);
        Achievement8Lock.SetActive(true);
    }
}
