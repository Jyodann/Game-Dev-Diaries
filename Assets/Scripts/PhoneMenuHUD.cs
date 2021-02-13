using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class PhoneMenuHUD : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdownList;

    [SerializeField] private TextMeshProUGUI statsText;
    // Start is called before the first frame update
    void Start()
    {
        dropdownList.options[1].text = "Notifications (2)";
        dropdownList.onValueChanged.AddListener(Changed);
        var data = GameDynamicData.Instance;
        var staticData = GameStaticData.Instance;
        var sb = new StringBuilder();

        if (data.currentGame != null)
        {
            sb.AppendLine($"Current Game: {data.currentGame.GameName}");
        }
        else
        {
            sb.AppendLine("Current Game: -");
        }

        sb.AppendLine($"Games Made: {data.CurrentGames.Count}");
        sb.AppendLine();
        sb.AppendLine($"Friends: {staticData.Friends.Count}");
        sb.AppendLine($"Fans: {data.Fans}");
        sb.AppendLine();
        sb.AppendLine($"Level: {data.CurrentLevel}");
        sb.AppendLine();
        sb.AppendLine($"Development Points: {data.CurrentProdCyclePoints[ProductionStageHUD.ProductionCycle.Development]}");
        sb.AppendLine($"Design Points: {data.CurrentProdCyclePoints[ProductionStageHUD.ProductionCycle.Design]}");
        sb.AppendLine($"Art/Sound Points: {data.CurrentProdCyclePoints[ProductionStageHUD.ProductionCycle.ArtSound]}");
        statsText.text = sb.ToString();
        
    }

    void Changed(int id)
    {
        print(id);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
