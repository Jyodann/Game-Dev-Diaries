using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool developerMode = false;
    [SerializeField] private string developerName;
    [SerializeField] private bool isFemale = false;
    [SerializeField] private bool isNewGame = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if (developerMode)
        {
            GameDynamicData.Instance.PlayerName = developerName;
            GameDynamicData.Instance.isPlayerFemale = isFemale;
            GameDynamicData.Instance.isNewGame = isNewGame;
        }
        
        if (GameDynamicData.Instance.isNewGame)
        {
            DialogManager.Instance.FindAndStartConversation("Introduction");

            DialogManager.Instance.FindQueueConversation("Tutorial");
        }

        ChooserMenu.OnButtonFinish += ChooserMenuOnOnButtonFinish;
    }

    private void ChooserMenuOnOnButtonFinish(string information)
    {
        print(information);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
