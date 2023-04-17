using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScoreLive : MonoBehaviour
{
    public static UIScoreLive instance;

    [SerializeField] TextMeshProUGUI scoreText;
    

    public int lives = 3;
    public int score = 0;

// Start is called before the first frame update
    void Start()
    {
        
    if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void UpdateScore(int scoreChange)
    {
        score += scoreChange;
        scoreText.text = score.ToString();
    }

    public void UpdateLives(int livesChange)
    {
        lives += livesChange;
    }
}
