using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject[] menuObjects;

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
}
