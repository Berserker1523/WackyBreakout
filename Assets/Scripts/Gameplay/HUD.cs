using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    static int actualScore = 0;
    static Text textScore;

    static int ballsLeft;
    static Text ballsLeftText;


    private void Start()
    {
        textScore = GameObject.FindGameObjectWithTag("TextScore").GetComponent<Text>();
        ballsLeft = ConfigurationUtils.BallsPerGame;
        ballsLeftText = GameObject.FindGameObjectWithTag("BallsLeftText").GetComponent<Text>();
    }

    public static void AddScore(int score)
    {
        actualScore += score;
        textScore.text = $"Score: {actualScore}";
    }

    public static void SubtractBallsLeft()
    {
        ballsLeft -= 1;
        ballsLeftText.text = $"Balls Left: {ballsLeft}";
    }
}
