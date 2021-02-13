using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyGift : MonoBehaviour
{
    public float costOfGift;
    public float currentStockOfGift;
    public float maxStockOfGift;
    [SerializeField] private TextMeshProUGUI costTMP;
    [SerializeField] private TextMeshProUGUI stockTMP;
    // Start is called before the first frame update
    void Start()
    {
        costTMP.text = $"Cost: ${costOfGift}";
        stockTMP.text = $"Stock: {currentStockOfGift}/{maxStockOfGift}";
    }

    public void BuyCurrentGift()
    {
        if (currentStockOfGift == 0)
        {
            Debug.Log("out of stock");
            return;
        }

        currentStockOfGift--;
        GameDynamicData.Instance.CurrentMoney -= costOfGift;
        
        costTMP.text = $"Cost: ${costOfGift}";
        stockTMP.text = $"Stock: {currentStockOfGift}/{maxStockOfGift}";

    }
}
