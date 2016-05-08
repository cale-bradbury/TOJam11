using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public Module[] list;

    void Awake()
    {
        list = GetComponentsInChildren<Module>();
    }

    public Module[] GetModulesOfType(Module.Types type)
    {
        return list.Where((x) => (x.type == type)).ToArray<Module>();
    }
}
