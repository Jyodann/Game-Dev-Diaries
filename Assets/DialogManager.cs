using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public delegate void EndConversation();

    public static event EndConversation OnEndConversation;
    
    private static DialogManager _instance;
    public static DialogManager Instance
    {
        get => _instance;
        set => _instance = value;
    }

    [HideInInspector] public Queue<Conversation> Conversations = new Queue<Conversation>();
    [SerializeField] private SpeakerUI leftSpeaker;
    [SerializeField] private SpeakerUI rightSpeaker;

    [SerializeField]private Conversation currentConversation;
    private Character currentCharacter;
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

            if (Conversations.Count == 0)
            {
                if (OnEndConversation != null)
                {
                    OnEndConversation();
                }
            }
            else
            {
                StartConversation(Conversations.Dequeue());
            }
            return;
        }
        
        if (!leftSpeaker.isReady || !rightSpeaker.isReady)
        {
            return;
        }

        if (!currentConversation.lines[convoIdx].Character)
        {
            currentConversation.lines[convoIdx].Character = currentCharacter;
        }
        else
        {
            currentCharacter = currentConversation.lines[convoIdx].Character;
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
    
    public void FindAndStartConversation(string conversationName)
    {
        var match = GameStaticData.Instance.Conversations.Find(x => x.name.Equals(conversationName));
        if (match == null)
        {
            Debug.LogError("Conversation Could not be found");
            return;
        }
        StartConversation(match);
    }
    
    public void FindQueueConversation(string conversationName)
    {
        var match = GameStaticData.Instance.Conversations.Find(x => x.name.Equals(conversationName));
        if (match == null)
        {
            Debug.LogError("Conversation Could not be found");
            return;
        }
        Conversations.Enqueue(match);
    }
}
