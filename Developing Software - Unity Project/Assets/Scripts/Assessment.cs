using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Linq;
using UnityEditor.VersionControl;
using System.Reflection;
using UnityEngine.SocialPlatforms.Impl;

public class Assessment : MonoBehaviour
{
    [SerializeField]
    TMP_Text messageDisplay;

    [SerializeField]
    TMP_Text playerNameDisplay;

    [SerializeField]
    TMP_Text playerScoreDisplay;

    [SerializeField]
    TMP_Text [] highScoreDisplays;

    [SerializeField]
    TMP_Text [] highScoreNameDisplays;

    bool highScoreAchieved = false;
    int playerScore = 0;
    string playerName = "";

    public void PrepareData()
    {
        //Get playerScore & playerName from PlayerPrefs
        playerScore = PlayerPrefs.GetInt("playerScore", 0);
        playerName = PlayerPrefs.GetString("playerName", "");

        //INITIALISE newScore and newName variables to be equal to playerScore and playerName
        int newScore = playerScore;
        string newName = playerName;

        //FOR scoreIndex from 0 to 3
        for (int scoreIndex = 0; scoreIndex < 3; scoreIndex++)
        {
            //READ highScore and highScoreName variables from Unity PlayerPrefs using the scoreIndex
            int highScore = PlayerPrefs.GetInt("highScore" + scoreIndex.ToString());
            string highScoreName = PlayerPrefs.GetString("highScoreName" + scoreIndex.ToString());

            //IF newScore is greater than highScore THEN
            if (newScore > highScore) 
            {
                //SET highScoreAchieved to true
                highScoreAchieved = true;

                string newScoreName = newName;

                //WRITE newScore and newScoreName variables into Unity PlayerPrefs forthe high score and high score name at this scoreIndex.

                PlayerPrefs.SetInt("highScore" + scoreIndex.ToString(), newScore);
                PlayerPrefs.SetString("highScoreName" + scoreIndex.ToString(), newName);

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
        //IF highScoreAchieved is true
        if (highScoreAchieved == true)
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

        //FOR scoreIndex from 0 to 3
        for (int scoreIndex = 0; scoreIndex < 3; scoreIndex++)
        {
            //READ highScore and highScoreName variables from Unity PlayerPrefs using the scoreIndex
            int highScore = PlayerPrefs.GetInt("highScore", 0);
            string highScoreName = PlayerPrefs.GetString("highScoreName", "");

            //CALL DisplayScore() with scoreIndex, highScore, and highScoreName
            DisplayScore(scoreIndex, highScore, highScoreName);

        }


    }

    public void DisplayScore(int index, int score, string name)
    {
        //IF score is greater than 0
        if (score > 0)
        {
            //2.9.2. DISPLAY score to the highScoreDisplays at index
            //highScoreDisplay[index].text = score.ToString();
            highScoreNameDisplays[index].text = score.ToString();


        }
        //2.9.3. ELSE
        else
        {
            //2.9.4. DISPLAY the empty string to the highScoreDisplays at index.
            highScoreDisplays[index].text = name;

        }
        //2.9.5. ENDIF


        //2.9.6. DISPLAY name to the highScoreNameDisplays at index
        name = highScoreNameDisplays[index].ToString();
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
