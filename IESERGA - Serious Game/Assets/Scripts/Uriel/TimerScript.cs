using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timerDuration = 10.0f; // Duration of the timer in seconds
    private float timeRemaining = 10.0f;
    private bool timerIsRunning = false;
    public TMP_Text timerText; // Reference to a UI Text component to display the timer

    void Start()
    {
        timeRemaining = timerDuration;
        timerIsRunning = false;
        timerText.enabled = false;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                if(timerText.enabled == false){

                    timerText.enabled = true;

                }

                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }

            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                timerText.enabled = false;
                Game_Manager.Instance.TriggerDefeat();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ActivateTimer(){
        timerIsRunning = true;
        timeRemaining = timerDuration;
    }
}