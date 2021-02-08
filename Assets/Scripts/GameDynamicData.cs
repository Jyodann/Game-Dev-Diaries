using System;

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

    public string PlayerName = String.Empty;
    public bool isPlayerFemale = true;
    public int currentLevel = 1;
    public int currentExp = 0;
    public bool isNewGame = true;
}
