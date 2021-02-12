using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Character")]
public class Character : ScriptableObject
{
    public string characterName;
    public Sprite portrait;
    public bool isOtherSpeaker = true;
    public int currentFriendshipPoints;
    [TextArea(4,10)]
    public string characterMeetMethod;
    

    [TextArea(4,10)]
    public string currentBenefits;
    [TextArea(4,10)]
    public string normalWhereabouts;
}
