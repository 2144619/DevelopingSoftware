using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Linq;
using UnityEditor.VersionControl;

public class Assessment : MonoBehaviour
{
    [SerializeField]
    TMP_Text messageDisplay;

    [SerializeField]
    TMP_Text playerNameDisplay;

    [SerializeField]
    TMP_Text playerScoreDisplay;

    [SerializeField]
    TMP_Text [] highScoreDisplay;

    [SerializeField]
    TMP_Text [] highScoreNameDisplay;

    bool highScoreAchieved = false;
    int playerScore = PlayerPrefs.GetInt("playerScore", 0);
    string playerName = PlayerPrefs.GetString("playerName", "");

    public void PrepareData()
    {
        //Get playerScore & playerName from PlayerPrefs
        int playerScore = PlayerPrefs.GetInt("playerScore", 0);
        string playerName = PlayerPrefs.GetString("playerName", "");

        //INITIALISE newScore and newName variables to be equal to playerScore and playerName
        int newScore = playerScore;
        string newName = playerName;

        //FOR scoreIndex from 0 to 3
        for (int scoreIndex = 0; scoreIndex < 3; scoreIndex++)
        {
            //READ highScore and highScoreName variables from Unity PlayerPrefs using the scoreIndex
            int highScore = PlayerPrefs.GetInt("highScore", 0);
            string highScoreName = PlayerPrefs.GetString("highScoreName", "");

            //IF newScore is greater than highScore THEN
            if (newScore > highScore) 
            {
                //SET highScoreAchieved to true
                bool highScoreAchieved = true;

                string newScoreName = newName;

                //WRITE newScore and newScoreName variables into Unity PlayerPrefs forthe high score and high score name at this scoreIndex.

                PlayerPrefs.SetInt("highScore" , newScore);
                PlayerPrefs.SetString("highScoreName", newScoreName);

                PlayerPrefs.Save();
                //SET newScore equal to highScore
                newScore = highScore;
                //SET newName equal to highScoreName
                newName = newScoreName;
            }
        }
    }

    public void DisplayData()
    {
        //2.1. IF highScoreAchieved is true
        if (highScoreAchieved)
        {

            //DISPLAY "Congratulations! You got a new high score!" to the messageDisplay text object.
            messageDisplay.text = "Congratulations! You got a new high score!";
        }        
        else
        {
            //DISPLAY "Better luck next time!" to the messageDisplay text object.
            messageDisplay.text = "Better luck next time!";
        }
        //DISPLAY playerName and playerScore to the playerNameDisplay and playerScoreDisplay text objects 
        playerName = playerNameDisplay.text;
        playerScoreDisplay.text = playerScore.ToString();

        for (int scoreIndex = 0; scoreIndex < 3; scoreIndex++)
        {
            int highScore = PlayerPrefs.GetInt("highScore", 0);
            string highScoreName = PlayerPrefs.GetString("highScoreName", "");


            DisplayScore(scoreIndex, highScore, highScoreName);
            
            

            


        }




    }

    public void DisplayScore(int scoreIndex, int highScore, string highScoreName)
    {
        //highScoreDisplay() = scoreIndex.ToString();
     
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
