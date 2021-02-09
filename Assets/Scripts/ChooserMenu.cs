using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooserMenu : MonoBehaviour
{
    public static ChooserMenu Instance;
    [SerializeField] private TextMeshProUGUI topicHeader;
    public delegate void OnButtonChosen(string information);

    public static event OnButtonChosen OnButtonFinish;

    [SerializeField] private GameObject genericChooserButton;

    [SerializeField] private GameObject contentParent;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void OpenMenuWithInformation(string menuTitle, List<string> information)
    {
        gameObject.SetActive(true);
        topicHeader.text = menuTitle;
        foreach (var topic in information)
        {
            var button = Instantiate(genericChooserButton, contentParent.transform).GetComponent<Button>();
            button.GetComponentInChildren<TextMeshProUGUI>().text = topic;
            button.onClick.AddListener(delegate { OnButtonFinish(topic); DestoryAllChildren(); gameObject.SetActive(false); }); 
        }
    }

    void DestoryAllChildren()
    {
        foreach (Transform children in contentParent.transform)
        {
            Destroy(children.gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
