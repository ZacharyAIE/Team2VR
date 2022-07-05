using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Stores possible ScoreUI types
/// </summary>
public enum ScoreUIType
{
    CORRECT,
    INCORRECT,
    CORRECT_RECORD,
    INCORRECT_RECORD
}

/// <summary>
/// This class is responsible for populating the score UI elements. It refers to the instance of <see cref="ScoreManager"/> to retrieve its data.
/// </summary>
public class ScoreUI : MonoBehaviour
{
    private ScoreManager scoreManager;
    public TMP_Text textBox;
    public ScoreUIType scoreUIType;

    void Start()
    {
        scoreManager = ScoreManager.instance;

        scoreManager.OnScoresChanged.AddListener(() => SetText());
    }

    void SetText()
    {
        switch (scoreUIType)
        {
            case ScoreUIType.CORRECT:
                {
                    textBox.text = scoreManager.score.ToString();
                    break;

                }
            case ScoreUIType.INCORRECT:
                {
                    textBox.text = scoreManager.incorrectScore.ToString();
                    break;

                }
            case ScoreUIType.CORRECT_RECORD:
                {
                    textBox.text = scoreManager.highScore.ToString();
                    break;

                }
            case ScoreUIType.INCORRECT_RECORD:
                {
                    textBox.text = scoreManager.incorrectHighScore.ToString();
                    break;
                }
            default:
                {
                    textBox.text = scoreManager.score.ToString();
                    Debug.LogWarning("No score type set on " + this.name);
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
