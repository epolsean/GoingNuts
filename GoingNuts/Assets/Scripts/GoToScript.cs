using UnityEngine;
using System.Collections;

public class GoToScript : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject Extras;
    public GameObject ExtrasMenu;
    public GameObject Achievements;
    public GameObject Highscores;
    public GameObject Credits;
    public GameObject Settings;
    public GameObject CheckReset;
    public GameObject CheckQuit;
    public GameObject CheckGameQuit;
    public GameObject PauseMenu;

    public void mainMenu()
    {
        Application.LoadLevel(0);
    }

    public void menu()
    {
        MainMenu.SetActive(true);
        Extras.SetActive(false);
        CheckQuit.SetActive(false);
        Settings.SetActive(false);
    }

    public void loading()
    {
        Application.LoadLevel(3);
    }

    public void mainScore()
    {
        Highscores.SetActive(true);
        ExtrasMenu.SetActive(false);
    }

    public void score()
    {
        Application.LoadLevel(2);
    }

    public void settings()
    {
        if (Application.loadedLevel == 0)
        {
            Settings.SetActive(true);
            MainMenu.SetActive(false);
            Extras.SetActive(false);
            CheckQuit.SetActive(false);
        }
        else
        {
            Settings.SetActive(true);
            PauseMenu.SetActive(false);
            CheckQuit.SetActive(false);
            CheckGameQuit.SetActive(false);
        }
    }

    public void pause()
    {
        PauseMenu.SetActive(true);
        Settings.SetActive(false);
        CheckQuit.SetActive(false);
        CheckGameQuit.SetActive(false);
    }

    public void extras()
    {
        Extras.SetActive(true);
        ExtrasMenu.SetActive(true);
        Achievements.SetActive(false);
        Highscores.SetActive(false);
        Credits.SetActive(false);
        MainMenu.SetActive(false);
        Settings.SetActive(false);
    }

    public void credits()
    {
        Credits.SetActive(true);
        ExtrasMenu.SetActive(false);
    }

    public void achievements()
    {
        Achievements.SetActive(true);
        ExtrasMenu.SetActive(false);
        CheckReset.SetActive(false);
    }

    public void play()
    {
        Application.LoadLevel(1);
    }

    public void checkQuit()
    {
        CheckQuit.SetActive(true);
    }

    public void checkGameQuit()
    {
        CheckGameQuit.SetActive(true);
    }

    public void checkReset()
    {
        CheckReset.SetActive(true);
    }

    public void switchViews()
    {
        if(PlayerPrefs.GetInt("view_mode") == 1)
            PlayerPrefs.SetInt("view_mode", 0);
        else
            PlayerPrefs.SetInt("view_mode", 1);
    }

    public void quit()
    {
        Application.Quit();
    }
}
