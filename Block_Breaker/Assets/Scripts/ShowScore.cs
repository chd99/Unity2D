using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    // config params
    [SerializeField] TextMeshProUGUI scoreText;

    GameSession theGameSession;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        theGameSession = FindObjectOfType<GameSession>();
        scoreText.text = theGameSession.GetScore().ToString();
    }
}
