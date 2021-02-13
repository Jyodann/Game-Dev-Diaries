using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FriendActions : MonoBehaviour
{
    public Character currentCharacter;

    public CongratulationsMenu CongratulationsMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AskToHangOut()
    {
        DialogManager.Instance.FindAndStartConversation(0, currentCharacter.Conversations);
        DialogManager.Instance.FindQueueConversation(1, currentCharacter.Conversations);
        DialogManager.OnNextConversationQueued += OnNextConversation;
        DialogManager.OnEndConversation += OnEndConversation;
    }

    private void OnEndConversation()
    {
        BackdropUI.Instance.HideHUD();
        var prefab = Instantiate(CongratulationsMenu);
        prefab.resultTitle = $"You hung out with {currentCharacter.characterName}";
        prefab.resultText =
            $"You gained: \n -5% friendship\n -1% less design time \n\nYou found out:\n -His favourite colour is blue";
        Destroy(gameObject);
        
    }

    private void OnNextConversation()
    {
        DialogManager.OnNextConversationQueued -= OnNextConversation;
        BackdropUI.Instance.ShowHUD(GameStaticData.Instance.backdrops[1]);
    }
}
