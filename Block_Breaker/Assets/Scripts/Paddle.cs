using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minPaddleX;
    [SerializeField] float maxPaddleX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse postion by Units, for transform.postison
        float mousePosInUnits  = Input.mousePosition.x / Screen.width * screenWidthUnits;

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minPaddleX, maxPaddleX);

        transform.position = paddlePos;
    }
}
