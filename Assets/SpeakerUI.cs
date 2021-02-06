using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpeakerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speakerName;
    [SerializeField] private TextMeshProUGUI speakerText;
    [SerializeField] private Image speakerImage;

    public void SetSpeaker(Character character)
    {
        speakerImage.sprite = character.portrait;
        speakerName.text = character.characterName;
    }

    public void ShowDialogBox() => gameObject.SetActive(true);
    public void HideDialogBox() => gameObject.SetActive(false);
    public void SetDialogVisible(bool isVisible) => gameObject.SetActive(isVisible);
    
}
