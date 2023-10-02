// Copyright (C) 2015-2019 ricimi - All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement.
// A Copy of the Asset Store EULA is available at http://unity3d.com/company/legal/as_terms.
using System;
using System.Collections;
using Managers;
using UI;
using UnityEngine;

namespace Ricimi
{
    // This class is responsible for loading the next scene in a transition (the core of
    // this work is performed in the Transition class, though).
    public class SceneTransition : MonoBehaviour
    {
        public string scene = "<Insert scene name>";
        public float duration = 1.0f;
        public Color color = Color.black;

        private LevelManager _levelManager;
        private void Start()
        {
            AssingLevelManager();
        }

        private void AssingLevelManager()
        {
            _levelManager = FindObjectOfType<LevelManager>();
        }

        public void NextLevel()
        {
            var nextLevelName = _levelManager.GetNextSceneName();
            Transition.LoadLevel(nextLevelName, duration, color);
        }
        public void LoseLevel()
        {
            Transition.LoadLevel(_levelManager.GetSceneName(), duration, color);
        }
    }

}