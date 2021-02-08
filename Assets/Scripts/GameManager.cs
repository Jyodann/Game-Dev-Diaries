using System;

public class GameManager {
    protected GameManager() {}
    private static GameManager _instance = null;

    // Singleton pattern implementation
    public static GameManager Instance {
        get {
            if (GameManager._instance == null) {
                GameManager._instance = new GameManager();
            }  
            return GameManager._instance;
        }
    }

    public string PlayerName = String.Empty;
    public bool isPlayerFemale = true;
    public int currentLevel = 1;
    public int currentExp = 0;
}
