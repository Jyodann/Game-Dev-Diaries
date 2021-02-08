using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStaticData : MonoBehaviour
{
    public Sprite[] characterPortraits;
    public List<Conversation> Conversations;
    public static GameStaticData Instance;

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
