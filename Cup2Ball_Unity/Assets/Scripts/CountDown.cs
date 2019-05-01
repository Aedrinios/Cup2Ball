using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public float wantedDuration;
    private float timeLeft;
    private bool timePass;

    void Start()
    {
        timeLeft = wantedDuration;
        timePass = true;
    }


    void Update()
    {
        if(timePass)
            UpdateTimer();
        
        if (timeLeft <= 0)
        {
            timePass = false;
            GameManager.Instance.EndGame();
        }
    }

    void UpdateTimer()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 10){
            timeText.color = Color.red;
        }
        float minutes = (int)(timeLeft / 60f);
        float seconds = (int)((timeLeft % 60));
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}