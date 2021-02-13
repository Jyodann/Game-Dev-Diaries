using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftsOwned : MonoBehaviour
{
    [SerializeField] private GameObject giftParent;
    [SerializeField] private Notification giftPrefab;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var gift in GameDynamicData.Instance.CurrentlyOwnedGifts)
        {
            var prefab = Instantiate(giftPrefab, giftParent.transform);
            prefab.IconDisplay = gift.GiftIcon;
            prefab.DescriptionDisplay = gift.GiftDescription;
            prefab.TitleDisplay = gift.GiftName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
