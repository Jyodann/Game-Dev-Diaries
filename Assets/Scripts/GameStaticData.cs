using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStaticData : MonoBehaviour
{
    public Sprite[] characterPortraits;
    public List<Conversation> Conversations;
    public static GameStaticData Instance;

    public readonly List<string> TargetGenders = new List<string>() {"Male", "Female", "General"};
    public readonly List<string> TargetAge = new List<string>()  {"Everyone", "Young Adults", "Mature"};

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
        
        
    }
}
