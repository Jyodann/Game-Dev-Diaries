using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DecisionUI : MonoBehaviour
{
    [SerializeField] private Image characterIcon;
    public Character currentCharacter;
    public Button choiceButtonPrefab;
    
    public TextMeshProUGUI decisionName;

    public GameObject decisionParent;

    public void OpenDecisionBox(Decision decision)
    {
        characterIcon.sprite = GameDynamicData.Instance.IsPlayerFemale
            ? GameStaticData.Instance.characterPortraits[1]
            : GameStaticData.Instance.characterPortraits[0];
        foreach (Transform child in decisionParent.transform)
        {
            Destroy(child.gameObject);
        }
        
        decisionName.text = decision.decisionTitle;

        for (int i = 0; i < decision.Choices.Length; i++)
        {
            var prefab = Instantiate(choiceButtonPrefab, decisionParent.transform);
            prefab.GetComponentInChildren<TextMeshProUGUI>().text = decision.Choices[i].choiceName;
            var i1 = i;
            prefab.onClick.AddListener(delegate { ShowChoiceDialog(decision.Choices[i1]); });
        }
    }
    
    public void ShowDialogBox() => gameObject.SetActive(true);
    public void HideDialogBox() => gameObject.SetActive(false);

    private void ShowChoiceDialog(Choice currentChoice)
    {
        print(currentChoice.choiceName);
        
        DialogManager.Instance.StartConversation(currentChoice.nextDialog);
    }
}
