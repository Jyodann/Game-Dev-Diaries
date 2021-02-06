using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject[] menuObjects;
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private Button playGameButton;
    [SerializeField] private Toggle femaleToggle;

    private void Start()
    {
        //DisplayMenu(0);
    }

    public void QuitGame() => Application.Quit();
    
    public void DisplayMenu(int displayId)
    {
        foreach (var menuObject in menuObjects)
        {
            menuObject.SetActive(false);
        }
        
        menuObjects[displayId].SetActive(true);
    }

    public void SetName()
    {
        if (nameInput.text.Equals(string.Empty))
        {
            playGameButton.interactable = false;
        }
        else
        {
            playGameButton.interactable = true;
        }
    }

    public void StartGame()
    {
        
    }
}
