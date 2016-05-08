using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class CarBuilderWindow : EditorWindow {

    CarBuilder builder;
    bool needsRepaint = false;
    bool refreshModule = false;

    [MenuItem("Car/Builder")]
    static void Init()
    {
        CarBuilderWindow c = EditorWindow.GetWindow<CarBuilderWindow>();
        c.builder = FindObjectOfType<CarBuilder>();
        c.builder.inventory = FindObjectOfType<Inventory>();
    }

    void OnGUI()
    {
        builder = (CarBuilder)EditorGUILayout.ObjectField("Builder", builder, typeof(CarBuilder), true);
        if (builder == null)
            return;
        builder.inventory = (Inventory)EditorGUILayout.ObjectField("Inventory", builder.inventory, typeof(Inventory), true);
        EditorGUILayout.BeginHorizontal();
        builder.car = (Car)EditorGUILayout.ObjectField("Car", builder.car, typeof(Car), true);
        if (GUILayout.Button("new car"))
        {
            GameObject g = new GameObject("new car");
            g.name = "car";
            builder.car = g.AddComponent<Car>();
            builder.car.name = g.name;
            builder.SetSocket(builder.car);
        }
        EditorGUILayout.EndHorizontal();

        if (builder.car == null)
            return;
        builder.car.name = builder.car.gameObject.name = EditorGUILayout.TextField("car name", builder.car.name);

        //starting to do socket stuff here

        //refresh constant create/destroy mode
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Refresh Module") || refreshModule)
        {
            builder.SetSocket(builder.activeSocket);
            builder.SelectModule(builder.cycleIndex);
        }
        refreshModule = EditorGUILayout.Toggle("Constant Refresh", refreshModule);
        needsRepaint = refreshModule;
        EditorGUILayout.EndHorizontal();


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
