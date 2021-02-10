using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanningStageHUD : MonoBehaviour
{
    [SerializeField] private TMP_InputField gameNameInputField;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button[] uiButtons;
    // Start is called before the first frame update
    private int selectedButtonId = 0;
    [SerializeField] private TextAsset nouns;
    [SerializeField] private TextAsset adjectives;
    public readonly string[] Titles = { "Choose a topic", "Choose a genre", "Choose a platform", "Choose a target gender", "Choose a target age rating"};
    private string[] nounList;
    private string[] adjectiveList;
    private TextInfo myTI;
    private List<string> currentList = null;

    private bool[] buttonBools;
    
    void Start()
    {
        nounList = nouns.text.Split('\n');
        adjectiveList = adjectives.text.Split('\n');
        myTI = new CultureInfo("en-US",false).TextInfo;
        buttonBools = new bool[uiButtons.Length];
    }

    public void RandomiseTitle()
    {
        gameNameInputField.text =
            myTI.ToTitleCase( $"{adjectiveList[Random.Range(0, adjectiveList.Length)]} {nounList[Random.Range(0, nounList.Length)]}");

        for (int i = 0; i < uiButtons.Length; i++)
        {
            switch (i)
            {
                case 0:
                    currentList = GameDynamicData.Instance.CurrentUserTopics;
                    break;
                case 1:
                    currentList = GameDynamicData.Instance.CurrentGenres;
                    break; 
                case 2:
                    currentList = GameDynamicData.Instance.CurrentPlatforms;
                    break; 
                case 3:
                    currentList = GameStaticData.Instance.TargetGenders;
                    break;
                case 4:
                    currentList = GameStaticData.Instance.TargetAge;
                    break;
            }

            uiButtons[i].GetComponentInChildren<TextMeshProUGUI>().text =
                currentList[Random.Range(0, currentList.Count)];
            buttonBools[i] = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTopicsButton(int buttonId)
    {
        
        selectedButtonId = buttonId;
        switch (buttonId)
        {
            case 0:
                currentList = GameDynamicData.Instance.CurrentUserTopics;
                break;
            case 1:
                currentList = GameDynamicData.Instance.CurrentGenres;
                break; 
            case 2:
                currentList = GameDynamicData.Instance.CurrentPlatforms;
                break; 
            case 3:
                currentList = GameStaticData.Instance.TargetGenders;
                break;
            case 4:
                currentList = GameStaticData.Instance.TargetAge;
                break;
        }
        ChooserMenu.Instance.OpenMenuWithInformation(Titles[buttonId], currentList);
        ChooserMenu.OnButtonFinish += ChooserMenuOnOnButtonFinishTopics;
    }
    
    

    private void ChooserMenuOnOnButtonFinishTopics(string information)
    {
        ChooserMenu.OnButtonFinish -= ChooserMenuOnOnButtonFinishTopics;
        uiButtons[selectedButtonId].GetComponentInChildren<TextMeshProUGUI>().text = information;
        buttonBools[selectedButtonId] = true;
        ValidateInfoChange();
    }

    public void ValidateInfoChange()
    {
        nextButton.interactable = false;
        if (string.IsNullOrEmpty(gameNameInputField.text))
        {
            return;
        }

        foreach (var boolean in buttonBools)
        {
            if (!boolean) return;
        }

        nextButton.interactable = true;
        //Debug.Log();
    }
}
