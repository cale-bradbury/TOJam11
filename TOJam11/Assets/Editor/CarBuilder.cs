using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

public class CarBuilder : EditorWindow {

    List<ModularComponent> components;
    Car car;

    [MenuItem ("Car/CarBuilder")]
    static void Init()
    {
        CarBuilder window = (CarBuilder)EditorWindow.GetWindow<CarBuilder>();
        window.Show();
        Object[] objs = AssetDatabase.LoadAllAssetsAtPath("Prefab/CarComponents");
        foreach(Object o in objs)
        {
            if (o.GetType() == typeof(GameObject))
            {
                GameObject g = (GameObject)o;
                ModularComponent[] m = g.GetComponentsInChildren<ModularComponent>();
                if (m.Length > 1)
                    Debug.Log("WARNING - object " + g.name + " has more than 1 ModularComponent");
                if (m.Length != 0)
                    window.components.Add(m[0]);
            }
        }
    }

    void OnGUI()
    {
        if (GUILayout.Button("re init"))
            Init();

        FindCar();
        if (car == null)
            return;


    }

    void FindCar()
    {
        car  = Selection.activeGameObject.GetComponentInChildren<Car>();
        if (car == null)
            car = Selection.activeGameObject.GetComponentInParent<Car>();
    }
}
