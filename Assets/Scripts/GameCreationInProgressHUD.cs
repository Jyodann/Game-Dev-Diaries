using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCreationInProgressHUD : MonoBehaviour
{
    [HideInInspector] public string startingText = "Working...";
    [HideInInspector] public int progressionStacks = 6;
    [HideInInspector] public float maxTimeForProgression = 3f;
    [HideInInspector] public float minTimeForProgression = 2f;
    
    [SerializeField] private TextMeshProUGUI progressText;

    [SerializeField] private Slider currentSliderProgress;
    // Start is called before the first frame update
    void Start()
    {
        progressText.text = startingText;
        StartCoroutine(GameDevProcess());
        //GameStaticData.Instance.WorkingText[Random.Range(0, GameStaticData.Instance.WorkingText.Length)];
    }

    
    IEnumerator GameDevProcess()
    {
        var randomProg = Random.Range(3, progressionStacks);
        currentSliderProgress.maxValue = randomProg;
        currentSliderProgress.minValue = 0;
        
        for (int i = 1; i <= randomProg; i++)
        {
            yield return new WaitForSeconds(Random.Range(minTimeForProgression, maxTimeForProgression));
            currentSliderProgress.value = i;
            progressText.text = GameStaticData.Instance.WorkingText[Random.Range(0, GameStaticData.Instance.WorkingText.Count)];
        }

        progressText.text = "Finished!";
        GameDynamicData.Instance.CurrentDateTime = GameDynamicData.Instance.CurrentDateTime.AddHours(4);
        Destroy(gameObject, 3f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
