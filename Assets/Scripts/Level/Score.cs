using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;
    public Text scoreText;
    public Text maxScoreText;
    private int currentScore, maxScore;
    private void Start()
    {
        maxScore = PlayerPrefs.GetInt("MaxScore");
        maxScoreText.text = "Max score: " + maxScore.ToString();
    }
    private void Update()
    {
        currentScore = (int)(player.position.z / 2);
        scoreText.text = "Score: " + currentScore.ToString();
        if (currentScore > maxScore)
        {
            maxScore = currentScore;
            maxScoreText.text = "Max score: " + maxScore.ToString();
            PlayerPrefs.SetInt("MaxScore", maxScore);
        }
        //if (!GameManager.IsGameStarted)
        //{
        //    Debug.Log("!!");
        //    PlayerPrefs.SetInt("MaxScore", maxScore);
        //}
    }
}