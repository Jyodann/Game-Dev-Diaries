using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCreationHUD : MonoBehaviour
{
    [SerializeField] private Image genderImage;
    [SerializeField] private Sprite[] genderIcons;
    [SerializeField] private Image ageRatingImage;
    [SerializeField] private Sprite[] ageIcons;
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
        var data = GameStaticData.Instance;
        var game = GameDynamicData.Instance.currentGame;

        switch (game.Gender)
        {
            case GameStaticData.Genders.General:
                genderImage.sprite = genderIcons[0];
                break;
            case GameStaticData.Genders.Female:
                genderImage.sprite = genderIcons[1];
                break;
            case GameStaticData.Genders.Males:
                genderImage.sprite = genderIcons[2];
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        switch (game.Age)
        {
            case GameStaticData.Ages.Everyone:
                ageRatingImage.sprite = ageIcons[0];
                break;
            case GameStaticData.Ages.Young_Adults:
                ageRatingImage.sprite = ageIcons[1];
                break;
            case GameStaticData.Ages.Mature:
                ageRatingImage.sprite = ageIcons[2];
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        gameTitleText.text = game.GameName;
        platformText.text = ReturnString(data.TargetPlatforms, game.Platform);
        topicText.text = ReturnString(data.TargetTopics, game.Topic);
        genreText.text = ReturnString(data.TargetGenres, game.Genre);

        gameHypeText.text = $"{game.HypeScore}%";
        timeSpentText.text = $"{game.TimeSpent}/{game.TimeToComplete}";
        gameStateText.text = ReturnString(data.AvailableGameStates, game.GameState);
        
        print($"Development: {game.ScriptingEngineScore}, {game.PhysicsScore}, {game.AIScore}");
        print($"Design: {game.LevelDesignScore}, {game.GameplayScore}, {game.StoryQuestScore}");
        print($"SoundArt: {game.DialogueScore}, {game.SoundFXScore}, {game.BGMScore}");
    }

    private string ReturnString<T>(IDictionary<string, T> currentDictionary, T lol)
    {
        foreach (var hello in currentDictionary)
        {
            if (hello.Value.Equals(lol))
            {
                return hello.Key;
            }
        }

        return string.Empty;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
