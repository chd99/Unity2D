using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // config params
    [Range(0.5f,5f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointPerBlock = 100;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    // state variables
    [SerializeField] int currrentScore = 0;

    private void Awake()
    {
        // singleton pattern for GameStatus for Score continue on next levels

        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currrentScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;

    }

    public void AddToScore()
    {
        currrentScore += pointPerBlock;
        scoreText.text = currrentScore.ToString();
    }

    public void RestGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public int TotalScore()
    {
        return currrentScore;
    }
}
