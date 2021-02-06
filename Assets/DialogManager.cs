using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{

    private static DialogManager _instance;
    public static DialogManager Instance
    {
        get => _instance;
        set => _instance = value;
    }

    [SerializeField] private SpeakerUI leftSpeaker;
    [SerializeField] private SpeakerUI rightSpeaker;

    [SerializeField]private Conversation currentConversation;
    private int convoIdx = 0;
    public float typingSpeed = 0.05f;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (currentConversation == null)
        {
            leftSpeaker.HideDialogBox();
            rightSpeaker.HideDialogBox();
        }
    }

    public void StartConversation(Conversation conversation)
    {
        convoIdx = 0;
        currentConversation = conversation;

        ContinueConversation();
    }

    public void ContinueConversation()
    {
        if (convoIdx > currentConversation.lines.Length - 1)
        {
            rightSpeaker.HideDialogBox();
            leftSpeaker.HideDialogBox();
            return;
        }

        if (!leftSpeaker.isReady || !rightSpeaker.isReady)
        {
            return;
        }
        if (currentConversation.lines[convoIdx].Character.isOtherSpeaker)
        {
            
            rightSpeaker.ShowDialogBox();
            leftSpeaker.HideDialogBox();
            rightSpeaker.SetLines(currentConversation.lines[convoIdx]);
        }
        else
        {
            
            leftSpeaker.ShowDialogBox();
            rightSpeaker.HideDialogBox();
            leftSpeaker.SetLines(currentConversation.lines[convoIdx]);
        }
        convoIdx++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A ))
        {
            StartConversation(currentConversation);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ContinueConversation();
        }
    }

    
}
