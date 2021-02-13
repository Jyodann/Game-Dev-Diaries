using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackdropUI : MonoBehaviour
{
    public static BackdropUI Instance;

    [SerializeField] private Image currentBackdrop;
    
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

    private void Start()
    {
        currentBackdrop.gameObject.SetActive(false);
    }

    public void ShowHUD(Sprite backdropToShow)
    {
        currentBackdrop.gameObject.SetActive(true);
        currentBackdrop.sprite = backdropToShow;
    }

    public void HideHUD() => currentBackdrop.gameObject.SetActive(false);

}
