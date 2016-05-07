using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class LocationsConnector : EditorWindow
{
    public GameObject connectionPrefab;
    [MenuItem ("Car/LocationConnectorWindow")]
    static void Init()
    {
        LocationsConnector window = (LocationsConnector)EditorWindow.GetWindow<LocationsConnector>();
        window.Show();
    }

    void OnSelectionChange()
    {
        Repaint();
    }

    void OnGUI()
    {

        connectionPrefab = (GameObject) EditorGUILayout.ObjectField("Connection Prefab", connectionPrefab, typeof(GameObject));

        GameObject[] selected = Selection.gameObjects;
        if (selected.Length != 2)
        {
            EditorGUILayout.LabelField("please select 2 connectionNodes");
            return;
        }


        LocationNode n1 = selected[0].GetComponent<LocationNode>();
        LocationNode n2 = selected[1].GetComponent<LocationNode>();

        if (n1 == null || n2 == null)
        {
            EditorGUILayout.LabelField("please select 2 connectionNodes");
            return;
        }
        for (int i = n1.Connections.Count - 1; i > -1; i--)
            if (n1.Connections[i] == null)
                n1.Connections.RemoveAt(i);
        for (int i = n2.Connections.Count - 1; i > -1; i--)
            if (n2.Connections[i] == null)
                n2.Connections.RemoveAt(i);


        LocationConnection connection = null;
        for (int i = 0; i < n1.Connections.Count; i++)
        {
            if (n1.Connections[i].GetOther(n1) == n2){
                connection = n1.Connections[i];
                break;
            }
        }
        if (connection!=null)
        {
            if (GUILayout.Button("Destroy Link"))
            {
                n1.Connections.Remove(connection);
                n2.Connections.Remove(connection);
                DestroyImmediate(connection.gameObject);
            }
        }
        else
        {
            if (GUILayout.Button("Create Link"))
            {
                GameObject g = Instantiate<GameObject>(connectionPrefab);
                connection = g.GetComponent<LocationConnection>();
                connection.nodeA = n1;
                connection.nodeB = n2;
                connection.SetPositions();
                n1.Connections.Add(connection);
                n2.Connections.Add(connection);
            }
        }     

    }

}