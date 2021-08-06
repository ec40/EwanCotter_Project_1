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

    public Animator Damagetaken;

    public void StartGame(int index)
    {
        currentTimer = timeLimit;
        lifeRemaining = 5;
 
    }
    private void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex > 0);
        {
            currentTimer += Time.deltaTime;
            SetTimer(currentTimer);
        }
    }

    void damageAnim()
    {
        Damagetaken.Play("Damage taken");
    }

   
    private void SetTimer(float value)
    {
        TimeSpan time = TimeSpan.FromSeconds(value);
        quizUI.TimerText.text = "Time:" + time.ToString("mm':'ss");

    }

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


