using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderValueScript : MonoBehaviour
{
    public Color currentSliderColor;
    private TextMeshProUGUI counter;
    private TextMeshProUGUI sliderTitle;
    private Image sliderColour;
    [HideInInspector] public Slider currentSlider;
    // Start is called before the first frame update
    void Awake()
    {
        var textComponents = GetComponentsInChildren<TextMeshProUGUI>();
        sliderColour = GetComponentsInChildren<Image>()[1];
        counter = textComponents[0];
        sliderTitle = textComponents[1];
        currentSlider = GetComponent<Slider>();
        counter.text = currentSlider.value.ToString("0");
        currentSlider.onValueChanged.AddListener(UpdateValue);

        sliderColour.color = currentSliderColor;
    }

    public void UpdateValue(float currentValue)
    {
        counter.text = currentValue.ToString("0");
        ProductionStageHUD.Instance.UpdateTotal();
    }

    public void SetSliderValueAndTitle(float value, string title, string colorHex)
    {
        ColorUtility.TryParseHtmlString(colorHex, out var color);
        currentSlider.value = value;
        sliderTitle.text = title;
        sliderColour.color = color;

        currentSliderColor = color;
    }

    public float GetSliderValue() => currentSlider.value;

    // Update is called once per frame
    void Update()
    {
        
    }
}
