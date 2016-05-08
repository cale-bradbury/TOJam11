using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(CarBuilder))]
public class CarBuilderEditor : Editor {

    CarBuilder builder;
    
    public override void OnInspectorGUI()
    {
        builder = target as CarBuilder;
        builder.inventory = (Inventory)EditorGUILayout.ObjectField("Inventory", builder.inventory, typeof(Inventory), true);
        EditorGUILayout.BeginHorizontal();
        builder.car = (Car)EditorGUILayout.ObjectField("Car", builder.car, typeof(Car), true);
        if (GUILayout.Button("new car"))
        {
            GameObject g = new GameObject("new car");
            builder.car = g.AddComponent<Car>();
        }
        else if (builder.car == null)
            return;

        builder.car.name = EditorGUILayout.TextArea("car name", builder.car.name);



    }

}
