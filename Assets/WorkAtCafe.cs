using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkAtCafe : MonoBehaviour
{
    [SerializeField] private CongratulationsMenu workAtCafeCongratulationsMenu;

    [SerializeField] private GiftShopStoreBuilder cafeShop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WorkAtCafeAction()
    {
        var prefab = Instantiate(workAtCafeCongratulationsMenu);
        prefab.resultTitle = "Work at Cafe";
        prefab.resultText = "You gained:\n -$60\n -200 EXP";

        GameDynamicData.Instance.CurrentMoney += 60;
        GameDynamicData.Instance.CurrentDateTime = GameDynamicData.Instance.CurrentDateTime.AddHours(8);
        GameDynamicData.Instance.CurrentExp += 200;
    }

    public void CafeGiftShop()
    {
        var prefab = Instantiate(cafeShop);
        prefab.Gifts = GameDynamicData.Instance.CafeGifts;
    }

    public void CloseHUD()
    {
        PlayerHUDManager.Instance.ChangeVisibility(true);
        Destroy(gameObject);
    }
}
