using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Choice", menuName = "Choice")]
public class Choice : ScriptableObject
{
   public string choiceName;
   public Conversation nextDialog;
}
