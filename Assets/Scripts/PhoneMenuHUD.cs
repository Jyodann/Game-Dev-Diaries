using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PhoneMenuHUD : MonoBehaviour
{
    public static PhoneMenuHUD Instance;
    [SerializeField] private GameObject MainMenu;
    
    [SerializeField] private TMP_Dropdown dropdownList;

    [SerializeField] private TextMeshProUGUI statsText;

    [SerializeField] private PhoneNotifications phoneNotifications;

    [SerializeField] private GameObject[] Menus;

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
        PauseMenu.canBePaused = false;
        dropdownList.onValueChanged.AddListener(Changed);
        RefreshStats();
        
        for (int i = 0; i < Menus.Length; i++)
        {
            Menus[i].SetActive(false);
            Menus[0].SetActive(true);
        }
    }

    public void ShowMainMenu(bool isVisible) => MainMenu.SetActive(isVisible); 
    private void RefreshStats()
    {
        var data = GameDynamicData.Instance;
        var staticData = GameStaticData.Instance;
        var sb = new StringBuilder();

        if (data.currentGame != null)
        {
            sb.AppendLine($"Current Game: {data.currentGame.GameName}");
        }
        else
        {
            sb.AppendLine("Current Game: -");
        }

        sb.AppendLine($"Games Made: {data.CurrentGames.Count}");
        sb.AppendLine();
        sb.AppendLine($"Friends: {staticData.Friends.Count}");
        sb.AppendLine($"Fans: {data.Fans}");
        sb.AppendLine();
        sb.AppendLine($"Level: {data.ReturnLevel()}");
        sb.AppendLine();
        sb.AppendLine($"Development Points: {data.CurrentProdCyclePoints[ProductionStageHUD.ProductionCycle.Development]}");
        sb.AppendLine($"Design Points: {data.CurrentProdCyclePoints[ProductionStageHUD.ProductionCycle.Design]}");
        sb.AppendLine($"Art/Sound Points: {data.CurrentProdCyclePoints[ProductionStageHUD.ProductionCycle.ArtSound]}");
        statsText.text = sb.ToString();
    }

    void Changed(int id)
    {
        for (int i = 0; i < Menus.Length; i++)
        {
            Menus[i].SetActive(false);
            Menus[id].SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.canBePaused = true;
            DateTimeHUD.isPhoneShown = false;
            Destroy(gameObject);
        }
    }
}
