using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assessment : MonoBehaviour
{
    public void PrepareData()
    {
        //Get playerScore & playerName from PlayerPrefs
        int playerScore = PlayerPrefs.GetInt("playerScore", 0);
        string playerName = PlayerPrefs.GetString("playerName", "");

        int newScore = playerScore;
        string newName = playerName;

        for (int scoreIndex = 0; scoreIndex < 9; scoreIndex++)
        {
            int highScore = PlayerPrefs.GetInt("highScore", 0);
            string highScoreName = PlayerPrefs.GetString("highScoreName", "");
            if (newScore > highScore) 
            {
                Boolean highScoreAchieved = true;

                newScore = PlayerPrefs.SetInt("highScore" + slot, highScore);
                string newScoreName = PlayerPrefs.SetString("highScoreName", highScoreName);
                PlayerPrefs.SetFloat("sfxVolume" + slot, sfxVolume);

                PlayerPrefs.Save();
                newScore = highScore;
                newName = newScoreName;

            }
        }
    }

    public void DisplayData()
    {




    }
    // Start is called before the first frame update
    void Start()
    {
        PrepareData();
        DisplayData();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
