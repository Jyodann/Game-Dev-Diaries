using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolActionsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerHUDManager.Instance.ChangeVisibility(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseHUD()
    {
        PlayerHUDManager.Instance.ChangeVisibility(true);
        Destroy(gameObject);
    } 
    public void OpenPrefab(GameObject prefab) => Instantiate(prefab);
}
