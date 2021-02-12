using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class CongratulationsMenu : MonoBehaviour
{
    public string resultTitle;
    public string resultText;
    public Reward newReward = new Reward();
    [SerializeField] private TextMeshProUGUI resultTitleTMP;
    [SerializeField] private TextMeshProUGUI resultTextTMP;

    private void Start()
    { 
          
        if (!string.IsNullOrEmpty(resultText))
        {
            resultTextTMP.text = resultText;
            resultTitleTMP.text = resultTitle;
            return;
        }
        
        StringBuilder sb = new StringBuilder();
        
        if (newReward.hasGainedMoneyOrExp)
        {
            sb.AppendLine($"You gained:");

            if (newReward.exp != 0)
            {
                sb.AppendLine($"{newReward.exp} EXP");
            }

            if (newReward.moneyToGain != 0)
            {
                sb.AppendLine($"${newReward.moneyToGain}");
            }
        }
        
        if (newReward.topicsLearnt.Count != 0)
        {
            sb.AppendLine("You learnt these topics:");

            foreach (var topic in newReward.topicsLearnt)
            {
                sb.AppendLine($"- {topic.ToString()}");
            }
        }
        
        if (newReward.genresLearnt.Count != 0)
        {
            sb.AppendLine("You learnt these genres:");

            foreach (var topic in newReward.genresLearnt)
            {
                sb.AppendLine($"- {topic.ToString()}");
            }
        }
        resultTextTMP.text = sb.ToString();
      

    }

    public void CloseHUD()
    {
        Destroy(gameObject);
    }
}

public class Reward
{
    public bool hasGainedMoneyOrExp = false;
    public float exp = 0;
    public float moneyToGain = 0;
    public List<GameStaticData.Genres> genresLearnt = new List<GameStaticData.Genres>();
    public List<GameStaticData.Topics> topicsLearnt = new List<GameStaticData.Topics>();
}
