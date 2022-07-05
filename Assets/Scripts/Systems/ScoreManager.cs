using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is responsible for giving points, it stores the last score in <see cref="PlayerPrefs"/>
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public int incorrectScore = 0;
    public int highScore = 0;
    public int incorrectHighScore = 0;
    public UnityEvent OnScoresChanged;

    // On awake create an instanse of this class 
    private void Awake()
    {
        instance = this;
    }

    // On start set-up the UI components and previous high score
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore", 0);
        highScore = PlayerPrefs.GetInt("Failure Highscore", 0);
    }

    // Add points, update the UI and store the highscore in playerprefrance for next game
    // pass a -x value to remove points
    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        if (highScore < score)
            PlayerPrefs.SetInt("Highscore", score);
        OnScoresChanged.Invoke();
    }

    public void AddIncorrectPoints(int pointsToAdd)
    {
        incorrectScore += pointsToAdd;
        if (incorrectHighScore < incorrectScore)
            PlayerPrefs.SetInt("Failure_Highscore", incorrectScore);
        OnScoresChanged.Invoke();
    }
}
