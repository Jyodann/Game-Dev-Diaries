using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SocialTiesMenu : MonoBehaviour
{
    [SerializeField] private GameObject socialTieParent;

    [SerializeField] private Notification socialTieInformation;

    private void Start()
    {
        foreach (var friend in GameStaticData.Instance.Friends)
        {
            var prefab = Instantiate(socialTieInformation, socialTieParent.transform);
            prefab.IconDisplay = friend.portrait;
            prefab.TitleDisplay = friend.characterName;
            prefab.DescriptionDisplay =
                $"{friend.characterMeetMethod}\nRelationship: {friend.currentFriendshipPoints}/100";
            prefab.GetComponent<Button>().onClick.AddListener(delegate { FriendInformationDisplay.Instance.DisplayHUD(friend); gameObject.SetActive(false);});
        }
    }
}
