using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
public class Conversation : ScriptableObject
{
    public Character speakerLeft;
    public Character speakerRight;
    public CharacterLines[] lines;
}


