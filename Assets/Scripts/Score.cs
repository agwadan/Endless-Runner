using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 10;
    
    private float score = 0.0f;

     private bool isDead = false;
    
    public Text scoreText;
    public DeathMenu deathMenu;
   

    void Update(){

        if(isDead){
            return;
        }

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

    public void OnDeath(){
        isDead = true;
        if(PlayerPrefs.GetFloat("HighScore") < score){
            PlayerPrefs.SetFloat("HighScore", score);
        }
        deathMenu.ToggleEndMenu(score);
    }
}
