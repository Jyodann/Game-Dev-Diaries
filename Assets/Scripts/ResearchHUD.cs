using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchHUD : MonoBehaviour
{
    [SerializeField] private GameObject researchTimePrefab;

    private GameStaticData.ResearchType currentResearchType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseHUD() => Destroy(gameObject);

    public void OpenTopicChooser()
    {
        ChooserMenu.Instance.OpenMenuWithInformation("Choose Topic", GameDynamicData.Instance.CurrentUserTopics);
        currentResearchType = GameStaticData.ResearchType.Topic;
        ChooserMenu.OnButtonFinish += OnTopicChoose;
    }
    
    public void OpenGenreChooser()
    {
        ChooserMenu.Instance.OpenMenuWithInformation("Choose Genre", GameDynamicData.Instance.CurrentGenres);
        currentResearchType = GameStaticData.ResearchType.Genre;
        ChooserMenu.OnButtonFinish += OnTopicChoose;
    }
    
    public void OpenDiscovery()
    {
        ChooserMenu.OnButtonFinish -= OnTopicChoose;
        currentResearchType = GameStaticData.ResearchType.DiscoverGenreTopic;
        var window = Instantiate(researchTimePrefab).GetComponent<TopicToResearchMenu>();
        window.topic = "Topic and Genre Discovery";
        window.currentType = currentResearchType;
    }

    private void OnTopicChoose(string topic)
    {
        ChooserMenu.OnButtonFinish -= OnTopicChoose;
        var window = Instantiate(researchTimePrefab).GetComponent<TopicToResearchMenu>();
        window.topic = topic;
        window.currentType = currentResearchType;
    }
}
