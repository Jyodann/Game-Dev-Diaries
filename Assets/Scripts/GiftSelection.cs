using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSelection : MonoBehaviour
{
    public Character currentFriend;

    public GiftNotification giftInSelection;

    public GameObject giftSelectionParent;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var gifts in GameDynamicData.Instance.CurrentlyOwnedGifts)
        {
            var prefab = Instantiate(giftInSelection, giftSelectionParent.transform);
            prefab.currentFriend = currentFriend;
            prefab.currentGift = gifts;
            prefab.giftSelectScreen = this.gameObject;

            prefab.GetComponent<Notification>().IconDisplay = gifts.GiftIcon;
            prefab.GetComponent<Notification>().TitleDisplay = gifts.GiftName;
            prefab.GetComponent<Notification>().DescriptionDisplay = gifts.GiftDescription;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
