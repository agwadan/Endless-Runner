using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour{

    public Text highScoreText,
                coinsText;
    void Start()    {
        highScoreText.text = "HighScore: " + ((int)PlayerPrefs.GetFloat("HighScore"));
        coinsText.text     = "Coins: " + (PlayerPrefs.GetInt("CoinsCount"));
    }

    public void ToGame (){
        SceneManager.LoadScene("GameScene");
    }
}
