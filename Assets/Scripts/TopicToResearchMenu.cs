using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TopicToResearchMenu : MonoBehaviour
{
    [HideInInspector]
    public string topic;
    [SerializeField] private TextMeshProUGUI topicName;
    [SerializeField] private GameCreationInProgressHUD progress;
    [SerializeField] private CongratulationsMenu congratsMenu;

    public GameStaticData.ResearchType currentType;
    // Start is called before the first frame update
    void Start()
    {
        topicName.text = topic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseHUD() => Destroy(gameObject);

    public void OpenResearchWindow(int duration)
    {
        Instantiate(progress);
        GameDynamicData.Instance.CurrentDateTime = GameDynamicData.Instance.CurrentDateTime.AddHours(duration);
        GameCreationInProgressHUD.onCreationComplete += GameCreationInProgressHUDOnonCreationComplete;
    }

    private void GameCreationInProgressHUDOnonCreationComplete()
    {
        GameCreationInProgressHUD.onCreationComplete -= GameCreationInProgressHUDOnonCreationComplete;
        print("Creation Complete");
        congratsMenu.resultTitle = "Your research brought back these results:";
        switch (currentType)
        {
            case GameStaticData.ResearchType.Genre:
                congratsMenu.resultText =
                    "You learnt that the Platformer Genre:\n- Appeals more to males\n- Tends to do better on the Console platforms\n- Usually come with a everyone rating\n";
                break;
            case GameStaticData.ResearchType.Topic:
                congratsMenu.resultText =
                    "You learnt that the Zombies topic:\n- Appeals more to males\n- Tends to do better on the PC platform\n- Usually come with a Mature rating\n";
                break;
            case GameStaticData.ResearchType.DiscoverGenreTopic:
                congratsMenu.resultText =
                    "You discovered these new topics:\n- Students\n- Teaching\n- Medicine\n\nYou also discovered these new genres:\n- Anime\n- Slice of life";
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        Instantiate(congratsMenu);
    }
} 
