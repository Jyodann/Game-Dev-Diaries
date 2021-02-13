using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneNotifications : MonoBehaviour
{
    [SerializeField] private GameObject notificationParent;

    [SerializeField] private Notification notification;

    [SerializeField] private ChatHeadsUI conversation;
    // Start is called before the first frame update
    void Start()
    {
        RefreshNotifications();
    }

    public void RefreshNotifications()
    {
        foreach (Transform child in notificationParent.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (var task in GameStaticData.Instance.Tasks)
        {
            var prefab = Instantiate(notification, notificationParent.transform);
            prefab.IconDisplay = task.Character.portrait;
            prefab.TitleDisplay = task.Character.characterName;
            prefab.DescriptionDisplay = task.TaskDescription;
            prefab.GetComponent<Button>().onClick.AddListener(delegate
            {
                PhoneMenuHUD.Instance.ShowMainMenu(false);
                gameObject.SetActive(false);
                conversation.currentTask = task; conversation.ShowConvo(); });
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
