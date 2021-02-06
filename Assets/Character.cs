using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Character")]
public class Character : ScriptableObject
{
    public string characterName;
    public Sprite portrait;
}
