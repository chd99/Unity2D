﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;  //Serialized for debugging purpose

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

    public void BlockDestoryed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
