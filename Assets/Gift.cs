using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Gift")]
public class Gift : ScriptableObject
{
    public string GiftName;
    public Sprite GiftIcon;
    [TextArea(2,5)]
    public string GiftDescription;

    public float currentStock;
    public float maxStock;
    public float price;
}
