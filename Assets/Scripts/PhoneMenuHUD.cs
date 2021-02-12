using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhoneMenuHUD : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdownList;
    // Start is called before the first frame update
    void Start()
    {
        dropdownList.options[1].text = "Notifications (2)";
        dropdownList.onValueChanged.AddListener(Changed);
    }

    void Changed(int id)
    {
        print(id);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
