﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI finalScoreText;
        [SerializeField] private GameObject winObject;
        [SerializeField] private GameObject loseObject;
        [SerializeField] private TextMeshProUGUI levelText;

        private RectTransform _rectTransform;
        private GemScoreController _gemScoreController;

        private int _finalScore;
        private void Awake()
        {
            InitComponents();
        }

        private void Start()
        {
            SignUpEvents();
            DisableCanvasObjects();
        }

        private void InitComponents()
        {
            _rectTransform = GetComponent<RectTransform>();
            _gemScoreController = GetComponentInChildren<GemScoreController>(true);
        }

        private void ChangeFinalScoreText(int score)
        {
            _finalScore = (_gemScoreController.gemCount * score);
            finalScoreText.text = _finalScore.ToString();
        }
        
        private void ChangeFinalScoreText(Vector3 dummyParameter)
        {
            _finalScore = _gemScoreController.gemCount + 1;
            finalScoreText.text = _finalScore.ToString();
        }

        private void SignUpEvents()
        {
            SignUpGameOverEvents();

            GameEvents.FinishScoreTriggerEvent += ChangeFinalScoreText;
            GameEvents.CollectableEvent += ChangeFinalScoreText;
        }
        
        private void SignUpGameOverEvents()
        {
            GameEvents.LoseEvent += OnLoseEvent;
            GameEvents.WinEvent += OnWinEvent;
        }

        private void OnWinEvent()
        {
            _gemScoreController.gameObject.SetActive(false);
            winObject.SetActive(true);
        }

        private void OnLoseEvent()
        {
            _gemScoreController.gameObject.SetActive(false);
            levelText.text = "LEVEL "+PlayerPrefs.GetInt("PlayerLevel").ToString();
            loseObject.SetActive(true);
        }

        private void DisableCanvasObjects()
        {
            winObject.SetActive(false);
            loseObject.SetActive(false);
        }
    }
}