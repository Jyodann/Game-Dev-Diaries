using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStaticData : MonoBehaviour
{
    public enum Genders
    {
        General, Female, Males
    }
    
    public enum Ages
    {
        Everyone, Young_Adults, Mature
    }
    
    public enum Platforms
    {
        YBox_One, MyStation_4, PC, Mobile, Mintendo_Swap, 
    }
    
    public enum Topics
    {
        Zombies, Computers, School, Running, Monsters, Plants, Animals, 
        Airplanes, Dance, Business, Mystery, Words, Game_Development, Fantasy, 
        Racing, Management, Memes, Movies, Medieval, Teaching
    }
    
    public enum Genres
    {
        Platformer, Shooter, Fighting, Stealth, Survival, Horror, Text, Visual_Novel,
        Interactive_Movie, RPG, MMORPG, Romance, Sandbox, Simulation, MOBA, Real_Time_Strategy, First_Person_Shooter,
        Sports, Puzzle, Action, Open_World
    }
    
    public enum GameStates
    {
        Only_An_Idea, Design_Document_Written, Concept_Art_Drawn,
        Alpha_Build_Available, Beta_Build_Available, Game_Done_but_buggy,
        Game_Finished
    }
    
    public enum ResearchType
    {
        Genre, Topic, DiscoverGenreTopic
    }

    public readonly List<string> WorkingText = new List<string>() { "Coding...", "Drawing...", "Eating...", "Drinking Coffee", "Thinking...", "Procrastinating...", "Designing...", "Writing...", "Watching tutorials...", "Browsing Stackoverflow..." };
   
    
    public Sprite[] characterPortraits;
    public List<Conversation> Conversations;
    public static GameStaticData Instance;
    public List<Character> Friends;
    public Sprite[] backdrops;

    public List<Gift> AvailableSchoolGifts;
    public List<Gift> AvailableCafeGifts;
    public List<Task> Tasks;
        
    public readonly Dictionary<string, Genders> TargetGenders = new Dictionary<string, Genders>();
    public readonly Dictionary<string, Ages> TargetAge = new Dictionary<string, Ages>();
    public readonly Dictionary<string, Platforms> TargetPlatforms = new Dictionary<string, Platforms>();
    public readonly Dictionary<string, Topics> TargetTopics = new Dictionary<string, Topics>();
    public readonly Dictionary<string, Genres> TargetGenres = new Dictionary<string, Genres>();
    public readonly Dictionary<string, GameStates> AvailableGameStates = new Dictionary<string, GameStates>();

    public readonly Dictionary<ProductionStageHUD.ProductionCycle, string[]> ProductionCycleFocus =
        new Dictionary<ProductionStageHUD.ProductionCycle, string[]>()
        {
            {ProductionStageHUD.ProductionCycle.Development, new[] {"Scripting/Engine", "Physics", "AI"}},
            {ProductionStageHUD.ProductionCycle.Design, new[] {"Level Design", "Gameplay", "Story/Quest"}},
            {ProductionStageHUD.ProductionCycle.ArtSound, new[] {"Dialogue", "Sound FX", "BackgroundMusic"}},
        };
    
    public readonly Dictionary<ProductionStageHUD.ProductionCycle, string> ProductionCycleTitles =
        new Dictionary<ProductionStageHUD.ProductionCycle, string>()
        {
            {ProductionStageHUD.ProductionCycle.Development, "Production: Development"},
            {ProductionStageHUD.ProductionCycle.Design, "Production: Design"},
            {ProductionStageHUD.ProductionCycle.ArtSound, "Production: Art/Sound"},
        };
    
    public readonly Dictionary<ProductionStageHUD.ProductionCycle, string> ProductionCycleColours =
        new Dictionary<ProductionStageHUD.ProductionCycle, string>()
        {
            {ProductionStageHUD.ProductionCycle.Development, "#68eb94"},
            {ProductionStageHUD.ProductionCycle.Design, "#f4f46e"},
            {ProductionStageHUD.ProductionCycle.ArtSound, "#f8b1b1"},
        };
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Genders gender in Enum.GetValues(typeof(Genders)))
        {
            TargetGenders[FormatString(gender.ToString())] = gender;
        }

        foreach (Ages age in Enum.GetValues(typeof(Ages)))
        {
            TargetAge[FormatString(age.ToString())] = age;
        }

        foreach (Platforms platform in Enum.GetValues(typeof(Platforms)))
        {
            TargetPlatforms[FormatString(platform.ToString())] = platform;
        }
        
        foreach (Topics topic in Enum.GetValues(typeof(Topics)))
        {
            TargetTopics[FormatString(topic.ToString())] = topic;
        }
        foreach (Genres genre in Enum.GetValues(typeof(Genres)))
        {
            TargetGenres[FormatString(genre.ToString())] = genre;
        }
        
        foreach (GameStates gameState in Enum.GetValues(typeof(GameStates)))
        {
            AvailableGameStates[FormatString(gameState.ToString())] = gameState;
        }

        foreach (var gift in GameStaticData.Instance.AvailableSchoolGifts)
        {
            
            GameDynamicData.Instance.SchoolGifts.Add(gift.Copy());
        }
        
        foreach (var gift in GameStaticData.Instance.AvailableCafeGifts)
        {
            GameDynamicData.Instance.CafeGifts.Add(gift.Copy());
        }

        
    }

    private static string FormatString(string stringToFormat) => stringToFormat.Replace('_', ' ');
    
    
    
}
public class Game
{
    
    public string GameName;
    public GameStaticData.Topics Topic;
    public GameStaticData.Genres Genre;
    public GameStaticData.Platforms Platform;
    public GameStaticData.Genders Gender;
    public GameStaticData.Ages Age;
    public GameStaticData.GameStates GameState;
    
    public float TimeToComplete;
    public float TimeSpent;
    public float HypeScore;
    public float MoneyCost;
    
    public float ScriptingEngineScore;
    public float PhysicsScore;
    public float AIScore;
    
    public float LevelDesignScore;
    public float GameplayScore;
    public float StoryQuestScore;
    
    public float DialogueScore;
    public float SoundFXScore;
    public float BGMScore;

    public void SetDevelopmentScore(float[] scores)
    {
        ScriptingEngineScore = scores[0];
        PhysicsScore = scores[1];
        AIScore = scores[2];
    }
    
    public void SetDesignScore(float[] scores)
    {
        LevelDesignScore = scores[0];
        GameplayScore = scores[1];
        StoryQuestScore = scores[2];
    }
    
    public void SetArtSoundScore(float[] scores)
    {
        DialogueScore = scores[0];
        SoundFXScore = scores[1];
        BGMScore = scores[2];
    }
}




