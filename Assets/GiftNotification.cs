using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftNotification : MonoBehaviour
{
    public Gift currentGift;

    public Character currentFriend;

    public GameObject giftSelectScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveGift()
    {
        GameDynamicData.Instance.CurrentlyOwnedGifts.Remove(currentGift);
        foreach (var favourite in currentFriend.favouriteGifts)
        {
            if (favourite.GiftIcon == currentGift.GiftIcon)
            {
                DialogManager.Instance.StartConversation(currentFriend.favouriteGiftReply);
                Destroy(giftSelectScreen.gameObject);
                return;
            }
        }
        
        foreach (var favourite in currentFriend.dislikeGifts)
        {
            if (favourite.GiftIcon == currentGift.GiftIcon)
            {
                DialogManager.Instance.StartConversation(currentFriend.dislikeGiftReply);
                Destroy(giftSelectScreen.gameObject);
                return;
            }
        }
        
        DialogManager.Instance.StartConversation(currentFriend.neutralGiftReply);
        
        Destroy(giftSelectScreen.gameObject);
    }
}
