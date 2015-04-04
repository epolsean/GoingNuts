using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class HighscoresScript : MonoBehaviour {

    public string FileName; // This contains the name of the file. Don't add the ".txt"
    // Assign in inspector
    private StreamWriter writer; // This is the writer that writes to the file
    public TextAsset asset; // Assign that variable through inspector
    private string assetText;

    public List<string[]> entries = new List<string[]>();
    public int[] scoreArray = new int[] {0,0,0,0,0,0,0,0,0,0};
    public string[] nameArray = new string[10];
    public Text[] scoreTextArray;
    public Text[] nameTextArray;
    public bool wrote;
    string text;
    string scores;

    void Start()
    {
        asset = Resources.Load("Assets/Files/" + FileName + ".txt") as TextAsset;
        wrote = false;

        ReadScores();
        UpdateOrder();
        UpdateScores();
        ReadScores();
    }

    void Update()
    {
        if (wrote == false)
        {
            UpdateOrder();
            UpdateScores();
            ReadScores();
            wrote = true;
        }
    }

    public void ReadScores()
    {
        string Path = "Assets/Files/" + FileName + ".txt";
        readTextFile(Path);
        scores = text;

        string[] sub = scores.Split('/',':');
        
        for (int i = 1; i < sub.Length; i++)
        {
            if (i % 2 == 0)
            {
                scoreArray[(i-1)/2] = int.Parse(sub[i]);
            }
            else
            {
                nameArray[(i-1)/2] = sub[i];
            }
        }

        for (int i = 0; i < nameArray.Length; i++)
        {
            entries.Add(new string[] { nameArray[i], scoreArray[i].ToString()});
        }

        for (int i = 0; i < scoreTextArray.Length; i++)
        {
            string[] tempArray = entries[i];
            scoreTextArray[i].text = tempArray[1];
            nameTextArray[i].text = tempArray[0];
        }
    }

    public void UpdateOrder()
    {
        int[] temp1 = new int[10];
        string[] temp2 = new string[10];
        int[] temp3 = new int[10];

        for (int i = 0; i < temp1.Length; i++)
        {
            temp1[i] = scoreArray[i];
            temp2[i] = nameArray[i];
        }

        Array.Sort(temp1);
        int term = 0;

        for (int i = 9; i > -1; i--)
        {
            for (int j = 0; j < 10; j++)
            {
                if (scoreArray[j] == temp1[i])
                {
                    temp2[term] = nameArray[j];
                    temp3[term] = temp1[i];
                    term++;
                    break;
                }
            }
        }

        for (int i = 0; i < temp1.Length; i++)
        {
            scoreArray[i] = temp3[i];
            nameArray[i] = temp2[i];
            entries[i] = new string[] { nameArray[i], scoreArray[i].ToString() };
        }
    }

    public void UpdateScores()
    {
        string Path = "Assets/Files/" + FileName + ".txt";
        scores = "";

        for (int i = 0; i < scoreArray.Length; i++)
        {
            scores += "/" + nameArray[i] + ":" + scoreArray[i].ToString();
        }

        System.IO.File.WriteAllText(Path, scores);
    }

    public void readTextFile(string file_path)
    {
        StreamReader inp_stm = new StreamReader(file_path);

        while (!inp_stm.EndOfStream)
        {
            text = inp_stm.ReadLine();
            // Do Something with the input. 
        }

        inp_stm.Close();
    }

    public void AddScore(string Name, int Score)
    {
        string[] temp = entries[9];
        int min = int.Parse(temp[1]);

        if (Score > min)
        {
            entries[9] = new string[] { Name, Score.ToString() };
            nameArray[9] = Name;
            scoreArray[9] = Score;
        }
        for (int i = 0; i < scoreArray.Length; i++)
        {
            print("Name: " + nameArray[i] + " / Score: " + scoreArray[i]);
        }
        wrote = false;
    }
}
