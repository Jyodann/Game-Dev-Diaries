using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task", menuName = "Task")]
public class Task : ScriptableObject
{
    public Character Character;
    public string TaskName;
    public string TaskDescription;

    public Conversation chatBubbleConversation;
    public Conversation taskConversation;
}
