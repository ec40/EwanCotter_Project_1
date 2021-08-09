//This file is responsible for the animation and sound that plays when the player is damaged 
//and initialising the in-game timer

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private float timeLimit = 45f;
    private float currentTimer;
    private int lifeRemaining = 5;

    //Animator object
    public Animator Damagetaken;
    
    //Start game
    public void StartGame(int index)
    {
        currentTimer = timeLimit;
        lifeRemaining = 5;
 
    }
    
    //Game timer
    private void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex > 0);
        {
            currentTimer += Time.deltaTime;
            SetTimer(currentTimer);
        }
    }
    //Play Damage animation
    void damageAnim()
    {
        Damagetaken.Play("Damage taken");
    }

   //Animate timer
    private void SetTimer(float value)
    {
        TimeSpan time = TimeSpan.FromSeconds(value);
        quizUI.TimerText.text = "Time:" + time.ToString("mm':'ss");

    }
    
    //Incorrect answer processing
    public void Answer(bool correct)
    {

        if (!correct)
        {
            lifeRemaining--;
            quizUI.ReduceLife(lifeRemaining);
            damageAnim();
            SoundManagerScript.PlaySound("oof");

            if (lifeRemaining <= 0)
            {
                quizUI.RetryButton();

            }
        }
    }
}


