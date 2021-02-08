using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHUDManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Image playerPortrait;
    [SerializeField] private TextMeshProUGUI nameText;
    // Start is called before the first frame update
    void Start()
    {
        var gameStaticData = GameStaticData.Instance;
        nameText.text = GameDynamicData.Instance.PlayerName;
        levelText.text = $"Level {GameDynamicData.Instance.currentLevel}";
        playerPortrait.sprite = GameDynamicData.Instance.isPlayerFemale ? gameStaticData.characterPortraits[1] : gameStaticData.characterPortraits[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
