using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHUDManager : MonoBehaviour
{
    public void OpenPrefab(GameObject prefab)
    {
        PlayerHUDManager.Instance.ChangeVisibility(false);
        Instantiate(prefab);
    }
}
