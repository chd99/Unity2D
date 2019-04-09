using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizzard : MonoBehaviour
{
    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;

    int guess;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        NextGuess();
    }

    public void OnPressHigher()
    {
        if (min < max)
            {
            min = guess + 1;
            }
        else
        {
            min = guess;
        }
            
        NextGuess();
    }

    public void OnPressLower()
    {
        if (min < max)
        {
            max = guess - 1;
        }
        else
        {
            max = guess;
        }
        
        NextGuess();
    }

    void NextGuess()
    {
        guess = Random.Range(min,max);
        guessText.text = guess.ToString();
    }

}
