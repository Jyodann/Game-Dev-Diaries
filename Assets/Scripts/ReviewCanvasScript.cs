using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReviewCanvasScript : MonoBehaviour
{
    [SerializeField] private Button nextButton;

    [SerializeField] private TextMeshProUGUI review1Text;
    [SerializeField] private TextMeshProUGUI reviewCompany1Text;
    [SerializeField] private TextMeshProUGUI review2Text;
    [SerializeField] private TextMeshProUGUI reviewCompany2Text;
    [SerializeField] private TextMeshProUGUI review3Text;
    [SerializeField] private TextMeshProUGUI reviewCompany3Text;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseHUD()
    {
        Destroy(gameObject);
    }
}
