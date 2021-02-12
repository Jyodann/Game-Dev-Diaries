using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FindFriend : MonoBehaviour
{
    public string LocationName;
    [SerializeField] private TextMeshProUGUI windowTitle;
    // Start is called before the first frame update
    void Start()
    {
        windowTitle.text = $"People currently in {LocationName.ToLower()}:";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseHUD() => Destroy(gameObject);
}
