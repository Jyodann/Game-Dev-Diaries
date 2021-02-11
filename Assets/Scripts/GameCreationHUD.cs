using System.Collections;
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
    [SerializeField] private GameObject launchGameButton;
    [SerializeField] private GameObject reviewsScreen;

    [SerializeField] private GameObject loadingBarPopup;
    // Start is called before the first frame update
    void Start()
    {
        RefreshData();
    }

    public void CloseHUD()
    { 
        HomeActionsScript.Instance.UpdateTitle();
        Destroy(gameObject);
    }

    private void RefreshData()
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

        if (game.TimeSpent == game.TimeToComplete)
        {
            foreach (Transform child in actionButtons.transform)
            {
                Destroy(child.gameObject);
            }

            var launchBtn = Instantiate(launchGameButton, actionButtons.transform);
            
            launchBtn.GetComponent<Button>().onClick.AddListener(delegate { ShowReviewsScreen();} );
        }
    }

    private void ShowReviewsScreen()
    {
        Instantiate(reviewsScreen);
        GameDynamicData.Instance.CurrentGames.Add(GameDynamicData.Instance.currentGame);
        GameDynamicData.Instance.currentGame = null;
        Destroy(gameObject);  
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

    public void WorkOnGame()
    {
        var bar =Instantiate(loadingBarPopup);
        bar.GetComponentInChildren<GameCreationInProgressHUD>().startingText = "Coding...";

        var game = GameDynamicData.Instance.currentGame;
        game.TimeSpent = Mathf.Clamp(game.TimeSpent += 4, 0, game.TimeToComplete);
        RefreshData();
    }

    public void AbandonProject()
    {
        GameDynamicData.Instance.currentGame = null;
        HomeActionsScript.Instance.UpdateTitle();
        Destroy(gameObject);  
    }
}
