﻿using System;
using System.Collections;
 using Managers;
 using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnlockPanelController : MonoBehaviour
{
    [SerializeField] private GameObject revealParticle;

    [SerializeField] private TextMeshProUGUI revealPercentageText;
    [SerializeField] private TextMeshProUGUI revealVehicleNameText;
    
    [SerializeField] private GameObject nextButton;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image revealImage;
    
    private float _unlockSpeed = 20f;
    
    private float _currentPercentage;
    private float _targetPercentage;
    
    private void Start()
    {
        Initialize();
        
        StartCoroutine(UnlockAnimation());
    }

    public void Initialize()
    {
        _currentPercentage = LevelManager.LevelData.revealStartPercentage;
        _targetPercentage = _currentPercentage + LevelManager.LevelData.revealPercentageIncrease;

        backgroundImage.sprite = LevelManager.LevelData.revealItem.darkSprite;
        revealImage.sprite = LevelManager.LevelData.revealItem.sprite;
        
        revealImage.fillAmount = _currentPercentage / 100f;
    }
    private IEnumerator UnlockAnimation()
    {
        while (Math.Abs(_targetPercentage - _currentPercentage) > 1f)
        {
            _currentPercentage += Time.deltaTime * _unlockSpeed;

            revealImage.fillAmount = _currentPercentage / 100f;
            revealPercentageText.text = ((int)_currentPercentage).ToString();
            
            yield return null;
        }
        
        revealImage.fillAmount = _targetPercentage / 100f;
        revealPercentageText.text = $"% {((int)_targetPercentage).ToString()}";

        if (_targetPercentage >= 100f)
        {
            revealVehicleNameText.text = LevelManager.LevelData.revealItem.name;
            revealVehicleNameText.gameObject.SetActive(true);
            
            revealPercentageText.transform.parent.gameObject.SetActive(false);
            
            revealParticle.SetActive(true);
        }
        
        nextButton.SetActive(true);
    }

    private void OnDestroy()
    {
        nextButton.SetActive(false);
        revealImage.fillAmount = 0f;
        revealParticle.SetActive(false);
    }
}