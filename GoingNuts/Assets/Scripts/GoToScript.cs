using UnityEngine;
using System.Collections;

public class GoToScript : MonoBehaviour {

    public void mainMenu()
    {
        Application.LoadLevel(0);
    }

    public void menu()
    {

    }

    public void loading()
    {
        Application.LoadLevel(3);
    }

    public void mainScore()
    {

    }

    public void score()
    {
        Application.LoadLevel(2);
    }

    public void settings()
    {

    }

    public void extras()
    {

    }

    public void play()
    {
        Application.LoadLevel(1);
    }

    public void checkQuit()
    {

    }

    public void quit()
    {
        Application.Quit();
    }
}
