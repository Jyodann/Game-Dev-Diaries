using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FindFriend : MonoBehaviour
{
    public List<string> FriendList;
    public string LocationName;
    [SerializeField] private GameObject friendButtonPrefab;
    [SerializeField] private GameObject friendListTransform;
    [SerializeField] private TextMeshProUGUI windowTitle;

    [SerializeField] private WindowScript friendActionWindow;
    // Start is called before the first frame update
    void Start()
    {
        windowTitle.text = $"People currently in {LocationName.ToLower()}:";
        foreach (var friend in GameStaticData.Instance.Friends)
        {
            
            var prefab = Instantiate(friendButtonPrefab, friendListTransform.transform);
            prefab.GetComponentInChildren<TextMeshProUGUI>().text = friend.characterName;
            prefab.GetComponent<Button>().onClick.AddListener(delegate { OpenActionWindow(friend); });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenActionWindow(Character friend)
    {
         var prefab =  Instantiate(friendActionWindow);
         prefab.WindowTitle = friend.characterName;
         prefab.WindowDescription = $"What would you like to do with {friend.characterName}?";
         prefab.GetComponent<FriendActions>().currentCharacter = friend;
    }

    public void CloseHUD() => Destroy(gameObject);
}
