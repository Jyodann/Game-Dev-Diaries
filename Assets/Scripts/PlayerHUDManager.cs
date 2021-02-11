﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHUDManager : MonoBehaviour
{
    public static PlayerHUDManager Instance;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Image playerPortrait;
    [SerializeField] private TextMeshProUGUI nameText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        var gameStaticData = GameStaticData.Instance;
        nameText.text = GameDynamicData.Instance.PlayerName;
        levelText.text = $"Level {GameDynamicData.Instance.CurrentLevel}";
        playerPortrait.sprite = GameDynamicData.Instance.IsPlayerFemale ? gameStaticData.characterPortraits[1] : gameStaticData.characterPortraits[0];
    }

    public void ChangeVisibility(bool isVisible) => gameObject.SetActive(isVisible);
}
