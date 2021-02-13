using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FriendInformationDisplay : MonoBehaviour
{
    public static FriendInformationDisplay Instance;
    [SerializeField] private Image characterPortrait;

    [SerializeField] private TextMeshProUGUI characterName;

    [SerializeField] private TextMeshProUGUI characterMeetMethod;

    [SerializeField] private TextMeshProUGUI characterBenefits;

    [SerializeField] private GameObject HUD;

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

    public void DisplayHUD(Character characterToDisplay)
    {
        PhoneMenuHUD.Instance.ShowMainMenu(false);
        HUD.SetActive(true);
        characterPortrait.sprite = characterToDisplay.portrait;
        characterName.text = characterToDisplay.characterName;
        characterMeetMethod.text =  $"{characterToDisplay.characterMeetMethod}\nRelationship: {characterToDisplay.currentFriendshipPoints}/100";
        characterBenefits.text =
            $"Friendship Benefits:\n{characterToDisplay.currentBenefits}\n\nWhereabouts/Habits:\n{characterToDisplay.normalWhereabouts}";
    }

    public void CloseHUD()
    {
        HUD.SetActive(false);
        PhoneMenuHUD.Instance.ShowMainMenu(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
