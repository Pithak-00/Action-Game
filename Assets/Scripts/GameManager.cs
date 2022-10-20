using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int score;

    static GameManager instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        //scoreText.text = score.ToString();
        FindObjectOfType<GameSession>().GetScoreTextUI().text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
    }
}
