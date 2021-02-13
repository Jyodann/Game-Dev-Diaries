using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public delegate void EndConversation();
    public delegate void QueueNextConversation();

    public static event EndConversation OnEndConversation;
    public static event QueueNextConversation OnNextConversationQueued;
    
    private static DialogManager _instance;
    public static DialogManager Instance
    {
        get => _instance;
        set => _instance = value;
    }

    [HideInInspector] public Queue<Conversation> Conversations = new Queue<Conversation>();
    [SerializeField] private SpeakerUI leftSpeaker;
    [SerializeField] private SpeakerUI rightSpeaker;
    [SerializeField] private DecisionUI decisionUI;

    [SerializeField]private Conversation currentConversation;
    private Character currentCharacter;
    private int convoIdx = -1;
    public float typingSpeed = 0.05f;
    public bool awaitDecision = false;

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
        decisionUI.HideDialogBox();
        ContinueConversation();
    }

    public void ContinueConversation()
    {
        awaitDecision = false;
        if (convoIdx == -1)
        {
            return;
        }
        if (convoIdx > currentConversation.lines.Length - 1)
        {
            rightSpeaker.HideDialogBox();
            leftSpeaker.HideDialogBox();

            if (Conversations.Count == 0)
            {
                if (currentConversation.optionalDecision != null)
                {
                    leftSpeaker.HideDialogBox();
                    rightSpeaker.HideDialogBox();
                    decisionUI.OpenDecisionBox(currentConversation.optionalDecision);
                    
                    decisionUI.ShowDialogBox();
                    awaitDecision = true;
                }
                
                if (OnEndConversation != null && !awaitDecision)
                {
                    print("Conversation Ended");
                    OnEndConversation();
                    convoIdx = -1;
                }
                
            }
            else
            {   
                print("Next Conversation Queued ");
                if (OnNextConversationQueued != null)
                {
                    OnNextConversationQueued.Invoke();
                }
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ContinueConversation();
        }
    }
    
    public void FindAndStartConversation(string conversationName, List<Conversation> conversations)
    {
        var match = conversations.Find(x => x.name.Equals(conversationName));
        if (match == null)
        {
            Debug.LogError("Conversation Could not be found");
            return;
        }
        StartConversation(match);
    }
    
    public void FindAndStartConversation(int conversationId, List<Conversation> conversations)
    {
        var match = conversations[conversationId];
        if (match == null)
        {
            Debug.LogError("Conversation Could not be found");
            return;
        }
        StartConversation(match);
    }
    
    public void FindQueueConversation(string conversationName, List<Conversation> conversations)
    {
        var match = conversations.Find(x => x.name.Equals(conversationName));
        if (match == null)
        {
            Debug.LogError("Conversation Could not be found");
            return;
        }
        Conversations.Enqueue(match);
    }
    
    public void FindQueueConversation(int conversationId, List<Conversation> conversations)
    {
        var match = conversations[conversationId];
        if (match == null)
        {
            Debug.LogError("Conversation Could not be found");
            return;
        }
        Conversations.Enqueue(match);
    }
}
