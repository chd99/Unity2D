using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    // cached component references
    Level level;

    private void CountActiveBalls()
    {
        level = FindObjectOfType<Level>();
        level.BallLost();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("====================A Ball Lost =====================");
        CountActiveBalls();
//        SceneManager.LoadScene("Game Over");
    }
}
