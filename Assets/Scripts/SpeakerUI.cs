using System;
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
    private CharacterLines charLines;
    public void SetLines(CharacterLines characterLine)
    {
        charLines = characterLine;
        var gameStaticData = GameStaticData.Instance;
        speakerImage.sprite = characterLine.Character.portrait;
        speakerName.text = characterLine.Character.characterName;
        speakerText.text = string.Empty;

        if (!characterLine.Character.portrait)
        {
            speakerImage.sprite = GameDynamicData.Instance.IsPlayerFemale ? gameStaticData.characterPortraits[1] : gameStaticData.characterPortraits[0];
            speakerName.text = GameDynamicData.Instance.PlayerName;
        }
        StartCoroutine(Type(characterLine.text));
        isReady = false;
    }

    public void ShowDialogBox() => gameObject.SetActive(true);
    public void HideDialogBox() => gameObject.SetActive(false);
    public void SetDialogVisible(bool isVisible) => gameObject.SetActive(isVisible);
    
    IEnumerator Type(string line)
    {
        isReady = false;
        button.SetActive(false);
     
        line = line.Replace("{:}", GameDynamicData.Instance.PlayerName);
        foreach (var letter in line.ToCharArray())
        {
            
            speakerText.text += letter;
            yield return new WaitForSeconds(DialogManager.Instance.typingSpeed);
        }
        button.SetActive(true);
        isReady = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines();
            speakerText.text = charLines.text;
            button.SetActive(true);
            isReady = true;
        }
    }
}
