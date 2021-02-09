using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanningStageHUD : MonoBehaviour
{
    [SerializeField] private TMP_InputField gameNameInputField;
    [SerializeField] private Button[] uiButtons;
    // Start is called before the first frame update
    private int selectedButtonId = 0;
    [SerializeField] private TextAsset nouns;
    [SerializeField] private TextAsset adjectives;
    public readonly string[] Titles = { "Choose a topic", "Choose a genre", "Choose a platform", "Choose a target gender", "Choose a target age rating:"};
    private string[] nounList;
    private string[] adjectiveList;


    void Start()
    {
        nounList = nouns.text.Split('\n');
        adjectiveList = adjectives.text.Split('\n');
    }

    public void RandomiseTitle()
    {
        TextInfo myTI = new CultureInfo("en-US",false).TextInfo;
        gameNameInputField.text =
            myTI.ToTitleCase( $"{adjectiveList[Random.Range(0, adjectiveList.Length)]} {nounList[Random.Range(0, nounList.Length)]}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTopicsButton(int buttonId)
    {
        List<string> currentList = null;
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
    }
}
