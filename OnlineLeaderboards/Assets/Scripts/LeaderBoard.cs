using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Dan.Main;
using System;
using UnityEngine.SocialPlatforms.Impl;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;

    //[SerializeField] private String[] badWords = { "fuck" };

    private string publicLeaderboardKey = 
    "f47cd2df0d65b460d4501028e162bcb5c9ff2028524cfb57802568c8bf49f204";

    private void Start()
    {
        GetLeaderboard();
    }

    //GetData
    public void GetLeaderboard() {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) =>
        {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for(int i = 0; i < loopLength; ++i)
            {
                names[i].text = msg[i].Username;

              

                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    //Set Score
    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) =>
        {

            //Delete badWords
            //if (System.Array.IndexOf (badWords, name) != -1) return;

            //Cut Username
            //username.Substring(0, 4);
            
            //Format
           
          
            GetLeaderboard();
        }));
    }
    

}