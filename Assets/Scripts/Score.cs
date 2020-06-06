using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    private float score = 0.0f;
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 10;
    public Text scoreText;

    void Update()
    {
        if(score >= scoreToNextLevel){
            LevelUp();
        }
        score += Time.deltaTime * difficultyLevel;
        scoreText.text = ((int)score).ToString();//---------------------- The score is truncated to an integer from a float.
    }

    void LevelUp(){
        if(difficultyLevel == maxDifficultyLevel){
            return;
        }
        scoreToNextLevel *= 2; //---------------------------------------- Stepping up the criteria for moving to the next level.
        difficultyLevel++;

        GetComponent<PlayerMotor>().SetSpeed (difficultyLevel); //------- Calling SetSpeed from PlayerMotor.
        Debug.Log(difficultyLevel);
    }
}
