using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu]
public class InventoryType : ScriptableObject
{
    public int count;
    public GameObject prefab;
}

public class Inventory : MonoBehaviour
{
    public List<InventoryType> list;
}
