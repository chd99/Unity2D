using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minPaddleX;
    [SerializeField] float maxPaddleX;

    // cached reference
    GameSession theGameSession;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse postion by Units, for transform.postison
//        float mousePosInUnits  = Input.mousePosition.x / Screen.width * screenWidthUnits;

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetPosX(), minPaddleX, maxPaddleX);

        transform.position = paddlePos;
    }

    private float GetPosX()
    {
//        Debug.Log("HasStarted："+ theBall.HasStarted());
//        Debug.Log("IsAutoPlayEnabled：" + theGameSession.IsAutoPlayEnabled());
        if (theGameSession.IsAutoPlayEnabled() && theBall.HasStarted())
        {
//            return theBall.transform.position.x;
            return Mathf.Clamp(theBall.transform.position.x, minPaddleX, maxPaddleX);
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthUnits;   //mousePosInUnits
        }
    }
}
