using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameDynamicData.Instance.isNewGame)
        {
            DialogManager.Instance.FindAndStartConversation("Introduction");

            DialogManager.Instance.FindQueueConversation("Tutorial");
        }
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
