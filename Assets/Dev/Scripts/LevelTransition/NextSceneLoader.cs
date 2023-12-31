﻿using System;
using System.Collections;
using System.Collections.Generic;
using Ricimi;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
    [SerializeField] private float delay = 2f;

    private void Awake()
    {
        ArrangePlayerPrefLevel();
        LevelScene();
    }

    private void ArrangePlayerPrefLevel()
    {
        var playerPref = PlayerPrefs.GetInt("PlayerLevel");
        playerPref = playerPref <= 0 ? 1 : playerPref;
        PlayerPrefs.SetInt("PlayerLevel", playerPref);
    }

    private void LevelScene()
    {
        var playerPref = PlayerPrefs.GetInt("PlayerLevel", 0);
        var sceneCount = SceneManager.sceneCountInBuildSettings;
        var playableSceneCount = sceneCount - 3;
        var mod = (playerPref % playableSceneCount);
        var index = mod > 0 ? mod + 1 : playableSceneCount + 1;

        var path = SceneUtility.GetScenePathByBuildIndex(index);
        var sceneName = path.Substring(0, path.Length - 6).Substring(path.LastIndexOf('/') + 1);
        Transition.LoadLevel(sceneName, delay, Color.white);

        /*var thisSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (thisSceneIndex != index)
        {
            var path = SceneUtility.GetScenePathByBuildIndex(index);
            var sceneName = path.Substring(0, path.Length - 6).Substring(path.LastIndexOf('/') + 1);
            /*SceneManager.LoadScene(index);#1#
            Transition.LoadLevel(sceneName, delay, Color.white);
        }*/
    }
}