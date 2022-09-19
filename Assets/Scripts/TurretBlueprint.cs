using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class TurretBlueprint 
{
    
    public GameObject prefab;
    public GameObject upgradePrefab;

    public TMP_Text costText;

    public int cost;
    public int upgradeCost;

    public int sellAmount;
    public int upgradeSellAmount;

}