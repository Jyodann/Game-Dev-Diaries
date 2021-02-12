using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchHUD : MonoBehaviour
{
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
        ChooserMenu.OnButtonFinish += OnTopicChoose;
    }
    
    public void OpenGenreChooser()
    {
        ChooserMenu.Instance.OpenMenuWithInformation("Choose genre to research on", GameDynamicData.Instance.CurrentGenres);
    }

    private void OnTopicChoose(string topic)
    {
        
    }
}
