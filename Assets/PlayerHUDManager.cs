using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHUDManager : MonoBehaviour
{
    [SerializeField] private Sprite[] playerSprites;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Image playerPortrait;
    [SerializeField] private TextMeshProUGUI nameText;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = GameManager.Instance.PlayerName;
        playerPortrait.sprite = GameManager.Instance.isPlayerFemale ? playerSprites[1] : playerSprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
