using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Decision", menuName = "Decision")]
public class Decision : ScriptableObject
{
    public string decisionTitle;
    public Choice[] Choices;
}

[Serializable]
public class Choice
{
    public string choiceName;
    public Conversation nextDialog;
}
