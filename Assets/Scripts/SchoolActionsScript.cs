using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SchoolActionsScript : MonoBehaviour
{
    [SerializeField] private FindFriend findFriendPrefab;

    [SerializeField] private GiftShopStoreBuilder buildShop;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHUDManager.Instance.ChangeVisibility(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseHUD()
    {
        PlayerHUDManager.Instance.ChangeVisibility(true);
        Destroy(gameObject);
    } 
    public void OpenPrefab(GameObject prefab) => Instantiate(prefab);

    public void OpenShop()
    {
        buildShop.Gifts = GameDynamicData.Instance.SchoolGifts;
        Instantiate(buildShop);
    }

    public void LookForFriends()
    {
        findFriendPrefab.FriendList = GameStaticData.Instance.Friends.Select(x => x.characterName).ToList();
        findFriendPrefab.LocationName = "school";
        Instantiate(findFriendPrefab);
    }
}
