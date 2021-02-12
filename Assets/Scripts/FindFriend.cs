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
            prefab.GetComponent<Button>().onClick.AddListener(delegate { OpenActionWindow(friend.characterName); });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenActionWindow(string friendName)
    {
         var prefab =  Instantiate(friendActionWindow);
         prefab.WindowTitle = friendName;
         prefab.WindowDescription = $"What would you like to do with {friendName}";
    }

    public void CloseHUD() => Destroy(gameObject);
}
