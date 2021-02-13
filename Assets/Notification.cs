using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    public string TitleDisplay;
    public string DescriptionDisplay;
    public Sprite IconDisplay;
    [SerializeField] private Image NotificationIcon;
    [SerializeField] private TextMeshProUGUI NotificationTitle;
    [SerializeField] private TextMeshProUGUI NotificationDesc;

    private void Start()
    {
        NotificationIcon.sprite = IconDisplay;
        NotificationTitle.text = TitleDisplay;
        NotificationDesc.text = DescriptionDisplay;
    }
}
