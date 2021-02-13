using System.Linq;
using UnityEngine;

public class SchoolActionsScript : MonoBehaviour
{
    [SerializeField] private GameObject completeTaskButton;
    [SerializeField] private FindFriend findFriendPrefab;

    [SerializeField] private GiftShopStoreBuilder buildShop;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHUDManager.Instance.ChangeVisibility(false);
        print(GameDynamicData.Instance.CurrentTasks.Count);
        if (GameDynamicData.Instance.CurrentTasks.Count != 0)
        {
            completeTaskButton.SetActive(true);
        }
        else
        {
            completeTaskButton.SetActive(false);
        }
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

    public void CompleteTask()
    {
        var task = GameDynamicData.Instance.CurrentTasks[0];
        DialogManager.Instance.StartConversation(task.taskConversation);
        DialogManager.OnEndConversation += DialogManagerOnOnEndConversation;
        GameDynamicData.Instance.CurrentTasks.Remove(task);
        DateTimeHUD.Instance.ShowQuestMenu(false);
        completeTaskButton.SetActive(false);
    }

    private void DialogManagerOnOnEndConversation()
    {
        DialogManager.OnEndConversation -= DialogManagerOnOnEndConversation;
        
    }

    public void LookForFriends()
    {
        findFriendPrefab.FriendList = GameStaticData.Instance.Friends.Select(x => x.characterName).ToList();
        findFriendPrefab.LocationName = "school";
        Instantiate(findFriendPrefab);
    }
}
