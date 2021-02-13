using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyGift : MonoBehaviour
{
    public Gift currentGift;
    [SerializeField] private TextMeshProUGUI costTMP;
    [SerializeField] private TextMeshProUGUI stockTMP;
    // Start is called before the first frame update
    void Start()
    {
        costTMP.text = $"Cost: ${currentGift.price}";
        stockTMP.text = $"Stock: {currentGift.currentStock}/{currentGift.maxStock}";
    }

    public void BuyCurrentGift()
    {
        if (currentGift.currentStock == 0)
        {
            Debug.Log("out of stock");
            return;
        }

        for (int i = 0; i < GameDynamicData.Instance.SchoolGifts.Count; i++)
        {
            if (currentGift.GiftName.Equals(GameDynamicData.Instance.SchoolGifts[i].GiftName))
            {
                GameDynamicData.Instance.SchoolGifts[i].currentStock--;
            }
        }
        
        for (int i = 0; i < GameDynamicData.Instance.CafeGifts.Count; i++)
        {
            if (currentGift.GiftName.Equals(GameDynamicData.Instance.CafeGifts[i].GiftName))
            {
                GameDynamicData.Instance.CafeGifts[i].currentStock--;
            }
        }
        GameDynamicData.Instance.CurrentMoney -= currentGift.price;
        
        costTMP.text = $"Cost: ${currentGift.price}";
        stockTMP.text = $"Stock: {currentGift.currentStock}/{currentGift.maxStock}";
        
        GameDynamicData.Instance.CurrentlyOwnedGifts.Add(currentGift);
    }
}
