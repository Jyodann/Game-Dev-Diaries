using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeActionsScript : MonoBehaviour
{
    public static HomeActionsScript Instance;
    [SerializeField] private GameObject planningPrefab;
    [SerializeField] private GameObject creationPrefab;
    [SerializeField] private Button workOnGameButton;
    [SerializeField] private Button researchButton;
    [SerializeField] private Button backToMap;
    
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateTitle();
    }

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

    public void UpdateTitle()
    {
        if (GameDynamicData.Instance.currentGame == null)
        {
            workOnGameButton.GetComponentInChildren<TextMeshProUGUI>().text = "Work on game";
        }
        else
        {
            workOnGameButton.GetComponentInChildren<TextMeshProUGUI>().text = "Continue working on game";
        }

        foreach (var game in GameDynamicData.Instance.CurrentGames)
        {
            print(game.GameName);
        }
    }

    public void WorkOnGame()
    {
        if (GameDynamicData.Instance.currentGame == null)
        {
            Instantiate(planningPrefab);
        }
        else
        {
            Instantiate(creationPrefab);
        }
    }
    public void OpenPrefab(GameObject prefab) => Instantiate(prefab); 
    public void CloseUI()
    {
        PlayerHUDManager.Instance.ChangeVisibility(true);
        Destroy(gameObject);
    }
}
