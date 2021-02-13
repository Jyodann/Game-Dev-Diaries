using System;
using System.Collections.Generic;

public class GameDynamicData {
    protected GameDynamicData() {}
    private static GameDynamicData _instance = null;

    // Singleton pattern implementation
    public static GameDynamicData Instance {
        get {
            if (GameDynamicData._instance == null) {
                GameDynamicData._instance = new GameDynamicData();
            }  
            return GameDynamicData._instance;
        }
    }

    public string PlayerName = string.Empty;
    public bool IsPlayerFemale = true;
    public int CurrentLevel = 1;
    public int CurrentExp = 0;
    public bool IsNewGame = true;
    private float _currentMoney = 10000f;
    public float Fans = 0;

    public float CurrentMoney
    {
        get => _currentMoney;
        set
        {
            _currentMoney = value;
            DateTimeHUD.Instance.UpdateDateTime();
        }
    }
    
    private DateTime dateTime = DateTime.Parse("23 Jan 2021 08:00");
    public DateTime CurrentDateTime
    {
        get => dateTime;
        set
        {
            dateTime = value;
            DateTimeHUD.Instance.UpdateDateTime();
        }
    }

    public Game currentGame;
    
    public List<string> CurrentUserTopics = new List<string>() { "Zombies", "Computers", "School", "Running", "Monsters", "Plants"};
    public List<string> CurrentGenres = new List<string>() { "Platformer", "Simulation", "Action", "Horror", "Romance", "Open World"};
    public List<string> CurrentPlatforms = new List<string>() { "PC", "Mobile", "YBox One", "MyStation 4", "Mintendo Swap" };
    public List<Game> CurrentGames = new List<Game>();
    
    public Dictionary<ProductionStageHUD.ProductionCycle, int> CurrentProdCyclePoints = new Dictionary<ProductionStageHUD.ProductionCycle, int>()
    {
        {ProductionStageHUD.ProductionCycle.Development, 5},
        {ProductionStageHUD.ProductionCycle.Design, 5},
        {ProductionStageHUD.ProductionCycle.ArtSound, 5},
    };

    public List<Gift> CurrentlyOwnedGifts = new List<Gift>();
    public List<Gift> SchoolGifts = new List<Gift>();
    public List<Gift> CafeGifts = new List<Gift>();
}




