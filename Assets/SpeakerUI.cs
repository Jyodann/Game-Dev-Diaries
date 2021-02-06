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
    [SerializeField] private GameObject button;
    public bool isReady = true;

    public void SetLines(CharacterLines characterLine)
    {
        speakerImage.sprite = characterLine.Character.portrait;
        speakerName.text = characterLine.Character.characterName;
        speakerText.text = string.Empty;
        StartCoroutine(Type(characterLine.text));
    }

    public void ShowDialogBox() => gameObject.SetActive(true);
    public void HideDialogBox() => gameObject.SetActive(false);
    public void SetDialogVisible(bool isVisible) => gameObject.SetActive(isVisible);
    
    IEnumerator Type(string line)
    {
        isReady = false;
        button.SetActive(false);
        foreach (var letter in line.ToCharArray())
        {
            speakerText.text += letter;
            yield return new WaitForSeconds(DialogManager.Instance.typingSpeed);
        }
        button.SetActive(true);
        isReady = true;
    }
    
}
