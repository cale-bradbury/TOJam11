using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(CarBuilder))]
public class CarBuilderEditor : Editor {

    CarBuilder builder;
    bool needsRepaint = false;
    
    public override void OnInspectorGUI()
    {
        builder = target as CarBuilder;
        builder.inventory = (Inventory)EditorGUILayout.ObjectField("Inventory", builder.inventory, typeof(Inventory), true);
        EditorGUILayout.BeginHorizontal();
        builder.car = (Car)EditorGUILayout.ObjectField("Car", builder.car, typeof(Car), true);
        if (GUILayout.Button("new car"))
        {
            GameObject g = new GameObject("new car");
            g.name = "car";
            builder.car = g.AddComponent<Car>();
        }
        EditorGUILayout.EndHorizontal();
        if (builder.car == null)
            return;

        builder.car.name = builder.car.gameObject.name = EditorGUILayout.TextField("car name", builder.car.name);

        //starting to do socket stuff here

        //set to car if no active socket
        if (builder.activeSocket == null)
            builder.SetSocket(builder.car);

        EditorGUILayout.BeginHorizontal();
        //cycle through the potential pieces that can go in the current socket
        if (GUILayout.Button("Cycle Module"))
            builder.CycleModule();
        string[] names = new string[builder.cycleModules.Length];
        for(int i = 0; i<builder.cycleModules.Length; i++){
            names[i] = builder.cycleModules[i].name;
        }
        int j = EditorGUILayout.Popup(builder.cycleIndex, names);
        if (j != builder.cycleIndex)
            builder.SelectModule(j);
        EditorGUILayout.EndHorizontal();

        //Show Parent sockets so one can work back up the tree
        EditorGUILayout.LabelField("parent Sockets");
        ShowParents();

        EditorGUILayout.LabelField("child Sockets");
        ShowChildren();

        if (needsRepaint)
            Repaint();
    }

    void ShowParents()
    {
        List<Module> p = new List<Module>();
        Socket s = builder.activeSocket;
        while (builder.car != s)
        {
            p.Add(s.parent);
            s = s.parent.parent;
        }
        p.Reverse();
        foreach (Module m in p)
        {
            if (GUILayout.Button(m.name))
            {
                builder.SetSocket(m.parent);
                needsRepaint = true;
            }
        }
    }

    void ShowChildren()
    {
        if (builder.activeSocket.child)
        {
            foreach (Socket s in builder.activeSocket.child.sockets)
            {
                if (GUILayout.Button(s.gameObject.name))
                {
                    builder.SetSocket(s);
                    needsRepaint = true;
                }
            }
        }
    }

}
