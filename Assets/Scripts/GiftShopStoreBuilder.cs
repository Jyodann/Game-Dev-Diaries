using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftShopStoreBuilder : MonoBehaviour
{
    public List<Gift> Gifts;

    public GameObject BuyGiftButton;

    public GameObject GiftParent;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var gift in Gifts)
        {
            var prefab = Instantiate(BuyGiftButton, GiftParent.transform);
            var notification = prefab.GetComponent<Notification>();
            notification.TitleDisplay = gift.GiftName;
            notification.DescriptionDisplay = gift.GiftDescription;
            notification.IconDisplay = gift.GiftIcon;

            var giftInfo = prefab.GetComponent<BuyGift>();
            giftInfo.currentGift = gift;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
