using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SleepSummary : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goodnightText;

    [SerializeField] private Image backdrop;
    // Start is called before the first frame update
    void Start()
    {
        GameDynamicData.Instance.CurrentDateTime = GameDynamicData.Instance.CurrentDateTime.AddDays(1);
        var timeSpan = new TimeSpan(8,0,0);
        GameDynamicData.Instance.CurrentDateTime = GameDynamicData.Instance.CurrentDateTime.Date + timeSpan;

        var currentDevJourney = (GameDynamicData.Instance.CurrentDateTime - DateTime.Parse("23 Jan 2021 08:00")).Days;
        var timePlaying = (DateTime.Now - GameDynamicData.Instance.StartPlayTime);
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Goodnight, {GameDynamicData.Instance.PlayerName}");
        sb.AppendLine($"Tomorrow's Date: {GameDynamicData.Instance.CurrentDateTime.ToShortDateString()}");
        sb.AppendLine($"Your development journey has gone on for {currentDevJourney} days");

        goodnightText.text = sb.ToString();
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        for (float i = 0; i <= 1; i += 0.05f)
        {
            goodnightText.color = new Color(1,1,1,i);
            backdrop.color = new Color(0,0,0,i);
            yield return new WaitForSeconds(0.05f);
        }
        
        yield return new WaitForSeconds(5f);
        
        for (float i = 1; i >= -1; i -= 0.05f)
        {
            goodnightText.color = new Color(1,1,1,i);
            backdrop.color = new Color(0,0,0,i);
            yield return new WaitForSeconds(0.05f);
        }
        
        Destroy(gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
