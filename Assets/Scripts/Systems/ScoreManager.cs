using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//To DO: add "ScoreManager.instance.AddPoints();" to the script where we want the points to be added
//To DO: add "ScoreManager.instance.RemovePoints();" to the script where we want the points to be taken away


// This class is responsible for giving points, it stores the last score in player pref
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshPro scoreText;
    public TextMeshPro highScoreText;



    private int score = 0;
    private int highScore = 0;

    // On awake create an instanse of this class 
    private void Awake()
    {
        instance = this;
    }

    // On start set-up the UI components and previous high score
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore", 0);
        //   XX POINTS
        // HIGHSCORE: XX
        scoreText.text = score.ToString() + "POINTS";
        highScoreText.text = "HIGHSCORE" + highScore.ToString();
    }

    // Add points, update the UI and store the highscore in playerprefrance for next game
    // pass a -x value to remove points
    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString() + "POINTS";
        if (highScore < score)
            PlayerPrefs.SetInt("Highscore", score);
    }
}
