using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FriendActions : MonoBehaviour
{
    public Character currentCharacter;
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
        
        DialogManager.OnEndConversation += DialogManagerOnOnEndConversation;
    }

    private void DialogManagerOnOnEndConversation()
    {
        DialogManager.OnEndConversation -= DialogManagerOnOnEndConversation;
        BackdropUI.Instance.ShowHUD(GameStaticData.Instance.backdrops[1]);
        
    }
}
