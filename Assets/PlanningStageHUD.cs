using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanningStageHUD : MonoBehaviour
{
    [SerializeField] private Button[] uiButtons;
    // Start is called before the first frame update
    private int selectedButtonId = 0;

    public readonly string[] Titles = { "Choose a topic", "Choose a genre", "Choose a platform", "Choose a target gender", "Choose a target age rating:"};
    void Start()
    {
        
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
