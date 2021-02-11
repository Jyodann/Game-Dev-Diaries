using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeActionsScript : MonoBehaviour
{
    [SerializeField] private Button workOnGameButton;
    [SerializeField] private Button researchButton;
    [SerializeField] private Button backToMap;
    // Start is called before the first frame update
    void Start()
    {
        if (GameDynamicData.Instance.currentGame == null)
        {
            workOnGameButton.GetComponentInChildren<TextMeshProUGUI>().text = "Work on game";
        }
        else
        {
            workOnGameButton.GetComponentInChildren<TextMeshProUGUI>().text = "Continue working on game";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPrefab(GameObject prefab) => Instantiate(prefab); 
    public void CloseUI()
    {
        PlayerHUDManager.Instance.ChangeVisibility(true);
        Destroy(gameObject);
    }
}
