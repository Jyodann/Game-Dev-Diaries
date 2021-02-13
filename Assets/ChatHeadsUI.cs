using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatHeadsUI : MonoBehaviour
{
    public Conversation chatConvo;
    [SerializeField] private GameObject chatParent;
    [SerializeField] private Notification senderMessage;
    [SerializeField] private Notification replyMessage;
    [SerializeField] private Button agreeToHelp;
    

    public void ShowConvo()
    {
        gameObject.SetActive(true);

        foreach (var line in chatConvo.lines)
        {
            if (line.Character.isOtherSpeaker)
            {
                var prefab = Instantiate(senderMessage, chatParent.transform);
                prefab.IconDisplay = line.Character.portrait;
                prefab.DescriptionDisplay = line.text;
                prefab.TitleDisplay = line.Character.characterName;
            }
            else
            {
                var prefab = Instantiate(replyMessage, chatParent.transform);
                prefab.DescriptionDisplay = line.text;
                prefab.TitleDisplay = "You";
            }
        }
    }

    public void AgreeToHelp()
    {
        
    }

    public void GoBack()
    {
        gameObject.SetActive(false);
    }
}
