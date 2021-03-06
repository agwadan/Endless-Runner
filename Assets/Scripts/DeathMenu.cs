﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour  {

    public Text ScoreText;
    public Image backgroundImage;
    private bool isShown = false;
    private float transition = 0.0f;
    [SerializeField] private GameObject PlayerUI; 
    
    void Start()    {
        gameObject.SetActive(false);
    }

    void Update()    {
        if(!isShown){
            return;
        }

        transition += Time.deltaTime;
        backgroundImage.color = Color.Lerp (new Color(0,0,0,0), Color.black, transition);
    }

    public void ToggleEndMenu(float score){

        PlayerUI.SetActive(false);
        gameObject.SetActive(true); 
        ScoreText.text  = ((int)score).ToString();
        isShown         = true;

    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Getting the name of the scene that is active in the background.
    }

    public void Menu(){
        SceneManager.LoadScene("MenuScene");
    }
}
