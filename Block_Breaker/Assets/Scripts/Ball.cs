//using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0f;

    // state
    Vector2 paddleToBallVector;

    bool hasStarted = false;

    // cached component references
    Level level;
    AudioSource myAudioSource;
    Rigidbody2D myRigbody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigbody2D = GetComponent<Rigidbody2D>();

        CountBalls();
    }

    private void CountBalls()
    {
        level = FindObjectOfType<Level>();
        level.CountBalls();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
        }

        LauchOnMouseClick();

    }

    private void LauchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0) && !hasStarted)
        {
            hasStarted = true;
            myRigbody2D.velocity = new Vector2(xPush, yPush);
//            Debug.Log("Paddle Unlocked");
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
//        Debug.Log("Paddle Locked");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor), 
            Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];  //get random audio from audio audioclip[]
            myAudioSource.PlayOneShot(clip);
            myRigbody2D.velocity += velocityTweak;
        }

    }

    public bool HasStarted()
    {
        return hasStarted;
    }
}
