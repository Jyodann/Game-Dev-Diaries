using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindowScript : MonoBehaviour
{
    public string WindowTitle;
    public string WindowDescription;
    [SerializeField] private TextMeshProUGUI windowTitle;
    [SerializeField] private TextMeshProUGUI windowDescription;
    // Start is called before the first frame update
    void Start()
    {
        windowTitle.text = WindowTitle;
        windowDescription.text = WindowDescription;
    }

    public void CloseHUD() => Destroy(gameObject);
}
