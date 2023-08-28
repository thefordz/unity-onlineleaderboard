using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TMP_InputField inputName;

    [Header("Random Score")]
    [SerializeField] private int minScore = 0;
    [SerializeField] private int maxScore = 9999;

    [Header("Time Score")]
    [SerializeField] private float startTime;
    [SerializeField] private bool isTimerRunning = false;
    [SerializeField] private TextMeshProUGUI timeScoreText;
    [SerializeField] private int timeScore;

    public UnityEvent<string, int> submitScoreEvent;


    //Score
    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, int.Parse(score.text));
    }

    //Score by time
    public void SubmitTimeScore()
    {
        submitScoreEvent.Invoke(inputName.text, timeScore);
    }

    //Random Score
    public void RandomScore()
    {
        int randomScore = Random.Range(minScore, maxScore + 1);
        score.text = randomScore.ToString();
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isTimerRunning = true;
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            timeScore = Mathf.FloorToInt(Time.time - startTime);

            string formattedTime = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(timeScore / 60), Mathf.FloorToInt(timeScore % 60));

            timeScoreText.text = formattedTime;
        }
    }

    public void StopTimer()
    {
        isTimerRunning=false;
        Debug.Log("Time Score : " + timeScore);
    }


}