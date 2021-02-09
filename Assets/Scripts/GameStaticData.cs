using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStaticData : MonoBehaviour
{
    public Sprite[] characterPortraits;
    public List<Conversation> Conversations;
    public static GameStaticData Instance;

    public readonly List<string> TargetGenders = new List<string>() {"Male", "Female", "General"};
    public readonly List<string> TargetAge = new List<string>()  {"Everyone", "Young Adults", "Mature"};
    
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
}
