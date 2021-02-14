using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool developerMode = false;
    [SerializeField] private string developerName;
    [SerializeField] private bool isFemale = false;
    [SerializeField] private bool isNewGame = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if (developerMode)
        {
            GameDynamicData.Instance.PlayerName = developerName;
            GameDynamicData.Instance.IsPlayerFemale = isFemale;
            GameDynamicData.Instance.IsNewGame = isNewGame;
        }
        if (GameDynamicData.Instance.IsNewGame)
        {
            DialogManager.Instance.FindAndStartConversation("Introduction", GameStaticData.Instance.Conversations);

            DialogManager.Instance.FindQueueConversation("Tutorial", GameStaticData.Instance.Conversations);
        }
        ChooserMenu.OnButtonFinish += ChooserMenuOnOnButtonFinish;
    }

    private void ChooserMenuOnOnButtonFinish(string information)
    {
        print(information);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameDynamicData.Instance.CurrentDateTime = GameDynamicData.Instance.CurrentDateTime.AddDays(7);
        }
    }
}
