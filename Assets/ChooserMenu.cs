using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooserMenu : MonoBehaviour
{
    public delegate void OnButtonChosen(string information);

    public static event OnButtonChosen OnButtonFinish;
    public List<string> topicList;

    [SerializeField] private GameObject genericChooserButton;

    [SerializeField] private GameObject contentParent;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var topic in topicList)
        {
            var button = Instantiate(genericChooserButton, contentParent.transform).GetComponent<Button>();
            button.GetComponentInChildren<TextMeshProUGUI>().text = topic;
            button.onClick.AddListener(delegate { OnButtonFinish(topic); }); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
