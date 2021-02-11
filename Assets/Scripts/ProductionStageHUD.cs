using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductionStageHUD : MonoBehaviour
{
    public static ProductionStageHUD Instance;
    [SerializeField] private GameObject HUD;
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private SliderValueScript[] _sliderValueScripts;
    [SerializeField] private Image windowImage;
    [SerializeField] private Sprite[] windowSprites;
    [SerializeField] private TextMeshProUGUI windowTitle;
    [SerializeField] private TextMeshProUGUI pointsUsedText;
    [SerializeField] private TextMeshProUGUI hoursToSpend;
    [SerializeField] private TextMeshProUGUI moneyToSpend;
    [SerializeField] private Button finishProduction;
    [SerializeField] private Image warningImage;
    public enum ProductionCycle { Development, Design, ArtSound }

    private ProductionCycle currentProductionCycle = ProductionCycle.Development;
    private Dictionary<ProductionCycle, float[]> currentValues = new Dictionary<ProductionCycle, float[]>();
    private float[] defaultFloat = new[] {1f, 1f, 1f};
    private List<ProductionCycle> _productionCycles = new List<ProductionCycle>();
    private int currentDevIdx = 0;
    private GameStaticData cacheInstance;
    public bool sliderValueHasChanged = true;

    private void Awake()
    {
        if (Instance== null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        cacheInstance = GameStaticData.Instance;
        foreach (ProductionCycle prodCycle in Enum.GetValues(typeof(ProductionCycle)))
        {
            _productionCycles.Add(prodCycle);
            currentValues[prodCycle] = defaultFloat;
        }
        currentProductionCycle = _productionCycles[currentDevIdx];
        previousButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (HUD.activeSelf)
        {
            SaveInformation();
            UpdateTotal();
        }
    }

    public void NextProductCycle()
    {
        SaveInformation();
        currentDevIdx++;
        currentProductionCycle = _productionCycles[currentDevIdx];
        if (currentDevIdx == _productionCycles.Count - 1)
        {
            nextButton.gameObject.SetActive(false);
            previousButton.gameObject.SetActive(true);
        }
        else
        {
            nextButton.gameObject.SetActive(true);
            previousButton.gameObject.SetActive(true);
        }

        UpdateSlideValues();
        
        windowTitle.text = GameStaticData.Instance.ProductionCycleTitles[currentProductionCycle];
        windowImage.sprite = windowSprites[currentDevIdx];
    }
    public void PreviousProductCycle()
    {
        SaveInformation();
        currentDevIdx--;
        currentProductionCycle = _productionCycles[currentDevIdx];
        if (currentDevIdx == 0)
        {
            previousButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(true);
        }
        else
        {
            previousButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
        }
        
        UpdateSlideValues();
        windowTitle.text = GameStaticData.Instance.ProductionCycleTitles[currentProductionCycle];
        windowImage.sprite = windowSprites[currentDevIdx];
    }
    public void UpdateTotal()
    {
        finishProduction.interactable = true;
        float pointsUsed = 0;
        float totalPointsUsed = 0;
        
        for (int i = 0; i < _sliderValueScripts.Length; i++)
        {
            pointsUsed += _sliderValueScripts[i].GetSliderValue();
        }
        
        pointsUsedText.text = $"Points Used: {pointsUsed}/{GameDynamicData.Instance.CurrentProdCyclePoints[currentProductionCycle]}";

        foreach (var prodCycle in currentValues)
        {
            var currentScore = 0f;
            foreach (var score in prodCycle.Value)
            {
                totalPointsUsed += score;
                currentScore += score;
            }

            if (currentScore > GameDynamicData.Instance.CurrentProdCyclePoints[prodCycle.Key])
            {
                finishProduction.interactable = false;
            }
        }
        hoursToSpend.text = $"{Mathf.Clamp(totalPointsUsed * 2f, 2f, Single.MaxValue)} h";
        moneyToSpend.text = $"{Mathf.Clamp((totalPointsUsed / 5f) * 250f, 50f, Single.MaxValue)}";
    }
    
    public void SaveInformation()
    {
        warningImage.gameObject.SetActive(false);
        var floatValues = new float[3];
        var values = 0f;
        for (int i = 0; i < _sliderValueScripts.Length; i++)
        {
            floatValues[i] = _sliderValueScripts[i].GetSliderValue();
            values += _sliderValueScripts[i].GetSliderValue();
        }

        if (values > GameDynamicData.Instance.CurrentProdCyclePoints[currentProductionCycle])
        {
            warningImage.gameObject.SetActive(true);
        }
        currentValues[currentProductionCycle] = floatValues;
    }

    private void UpdateSlideValues()
    {
        for (int i = 0; i < _sliderValueScripts.Length; i++)
        {
            _sliderValueScripts[i].SetSliderValueAndTitle(currentValues[currentProductionCycle][i],
                cacheInstance.ProductionCycleFocus[currentProductionCycle][i],
                cacheInstance.ProductionCycleColours[currentProductionCycle]);
        }
    }

    public void ResetCurrentCycleValues(ProductionCycle currentProdCycle)
    {
        currentValues[currentProdCycle] = defaultFloat;
        UpdateSlideValues();
    }

    public void ResetAllCycleValues()
    {
        foreach (ProductionCycle prodCycle in Enum.GetValues(typeof(ProductionCycle)))
        {
            currentValues[prodCycle] = defaultFloat;
        }

        UpdateSlideValues();
    }

    public void ShowHUD()
    {
        HUD.SetActive(true);
    }
}
