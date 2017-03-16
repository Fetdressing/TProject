﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : BaseClass {
    SpawnManager spawnManager; //den håller koll på när banan "börjat", alltså när man börjar räkna tid och hur mkt score man har förtillfället
    LevelManager levelManager;
    LevelLoader levelLoader;

    [System.NonSerialized]
    public int collectedPowerGlobes = 0;
    [System.NonSerialized]
    public int maxNrGlobes = 0;
    // Use this for initialization
    void Awake () {
        Init();
	}

    public override void Init()
    {
        base.Init();

        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        levelLoader = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelLoader>();
    }


    public int GetBestGlobesCollected() //hämtar för current map
    {
        Level currLevel = levelLoader.GetCurrLevel();
        if(currLevel.bestGlobesCollected < collectedPowerGlobes)
        {
            return collectedPowerGlobes;
        }
        return currLevel.bestGlobesCollected;
    }


    public void PowerGlobeCollected(int value)
    {
        collectedPowerGlobes += value;
        spawnManager.UpdateGlobesText(collectedPowerGlobes);
    }

    public void NewLevel()
    {
        try
        {
            spawnManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<SpawnManager>(); //denna behöver hämtas på nytt vid varje level
        }
        catch (Exception e)
        {
            //thats fine
        }

        if(spawnManager != null)
        {
            collectedPowerGlobes = 0;
            maxNrGlobes = spawnManager.GetMaxNrGlobes();
        }
    }
}
