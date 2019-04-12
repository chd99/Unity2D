using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Win : MonoBehaviour
{
    // config params
    [SerializeField] TextMeshProUGUI scoreText;

    GameSession theGameSession;

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        scoreText.text = theGameSession.TotalScore().ToString();
        DestroyImmediate(theGameSession);  //TODO: destory the DontDestroyOnLoad GameSession object
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
