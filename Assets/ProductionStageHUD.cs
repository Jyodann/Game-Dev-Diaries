using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductionStageHUD : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private SliderValueScript[] _sliderValueScripts;
    [SerializeField] private Image windowImage;
    [SerializeField] private Sprite[] windowSprites;
    public enum ProductionCycle { Development, Design, ArtSound }

    private ProductionCycle currentProductionCycle = ProductionCycle.Development;
    private Dictionary<ProductionCycle, float[]> currentValues = new Dictionary<ProductionCycle, float[]>();
    private float[] defaultFloat = new[] {1f, 1f, 1f};
    private List<ProductionCycle> _productionCycles = new List<ProductionCycle>();
    private int currentDevIdx = 0;
    private void Start()
    {
        
        foreach (ProductionCycle prodCycle in Enum.GetValues(typeof(ProductionCycle)))
        {
            _productionCycles.Add(prodCycle);
            currentValues[prodCycle] = defaultFloat;
        }
        currentProductionCycle = _productionCycles[currentDevIdx];
        previousButton.gameObject.SetActive(false);
    }

    public void UpdateProductCycleValues()
    {
        var floatValues = new float[_sliderValueScripts.Length];

        for (int i = 0; i < _sliderValueScripts.Length; i++)
        {
            floatValues[i] = _sliderValueScripts[i].GetSliderValue();
        }

        currentValues[currentProductionCycle] = floatValues;
    }

    public void NextProductCycle()
    {
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

        windowImage.sprite = windowSprites[currentDevIdx];
    }

    public void PreviousProductCycle()
    {
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
        windowImage.sprite = windowSprites[currentDevIdx];
    }
    
    public void ResetCurrentCycleValues(ProductionCycle currentProdCycle)
    {
        currentValues[currentProdCycle] = defaultFloat;
    }

    public void ResetAllCycleValues()
    {
        foreach (ProductionCycle prodCycle in Enum.GetValues(typeof(ProductionCycle)))
        {
            currentValues[prodCycle] = defaultFloat;
        }
    }
}
