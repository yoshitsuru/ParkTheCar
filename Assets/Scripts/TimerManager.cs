using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TimerManager : MonoBehaviour
{
   public float timeRemaining = 10;

   public bool timerIsRunning = false;

   public UIController uIController;
   
   private TextMeshProUGUI _timeText;

    void Start()
   {
        _timeText = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();
       timerIsRunning = true;
   }


   void Update()
   {
       if (timerIsRunning)
       {
           if (timeRemaining > 0)
           {
               timeRemaining -= Time.deltaTime;
               DisplayTime(timeRemaining);
           }
           else
           {
               timeRemaining = 0;
               timerIsRunning = false;
           }
       }
       // ゲームオーバー
       GameOver();
   }

   void DisplayTime(float timeToDisplay)
   {
       timeToDisplay += 1;

       float minutes = Mathf.FloorToInt(timeToDisplay / 60);
       float seconds = Mathf.FloorToInt(timeToDisplay % 60);

       _timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
   }

    public void GameOver()
    {
        // 制限時間が0になったらゲームオーバー
        if (!timerIsRunning)
        {
            uIController.ActiveGameOver();
        }
    }
}
