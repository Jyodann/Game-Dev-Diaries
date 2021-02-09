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
    
    public List<string> CurrentUserTopics = new List<string>() { "Zombies", "Computers", "School", "Running", "Monsters", "Plants"};
    public List<string> CurrentGenres = new List<string>() { "Platformer", "Simulation", "Action", "Horror", "Romance", "Open World"};
    public List<string> CurrentPlatforms = new List<string>() { "PC", "Mobile" };
}
