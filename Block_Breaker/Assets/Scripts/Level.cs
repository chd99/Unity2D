using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;  //Serialized for debugging purpose
    [SerializeField] int activeBalls;  //Serialized for debugging purpose

    //cached reference
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
            breakableBlocks++;
    }

    public void CountBalls()
    {
        activeBalls ++;
    }

    public void BlockDestoryed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

    public void BallLost()
    {
        activeBalls--;
        if (activeBalls <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
