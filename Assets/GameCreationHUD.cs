using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCreationHUD : MonoBehaviour
{
    [SerializeField] private Image genderImage;

    [SerializeField] private Image ageRatingImage;

    [SerializeField] private TextMeshProUGUI gameTitleText;

    [SerializeField] private TextMeshProUGUI platformText;

    [SerializeField] private TextMeshProUGUI topicText;

    [SerializeField] private TextMeshProUGUI genreText;

    [SerializeField] private TextMeshProUGUI gameHypeText;

    [SerializeField] private TextMeshProUGUI timeSpentText;

    [SerializeField] private TextMeshProUGUI gameStateText;

    [SerializeField] private GameObject actionButtons;
    // Start is called before the first frame update
    void Start()
    {
        print(ProductionStageHUD.ProductionCycle.Development.ToString());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
