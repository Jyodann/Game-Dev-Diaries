using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DateTimeHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;

    [SerializeField] private TextMeshProUGUI dateText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Button phoneButton;
    
    // Start is called before the first frame update
    void Start()
    {
        var dateTime = GameDynamicData.Instance.currentDateTime;
        timeText.text = dateTime.ToString("t");
        dateText.text = $"{dateTime.ToShortDateString()} {dateTime:ddd}";
        moneyText.text = $"${GameDynamicData.Instance.CurrentMoney.ToString()}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPhoneVisibility(bool isVisible) => phoneButton.gameObject.SetActive(isVisible);
}
