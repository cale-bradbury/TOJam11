using UnityEngine;
using System.Collections;
using UnityEditor;

//Creates a custom Label on the inspector for all the scripts named ScriptName
// Make sure you have a ScriptName script in your
// project, else this will not work.
[CustomEditor(typeof(LocationNode))]
public class MapInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Debug.Log("test!");
        // We are trying to get locaction nodes to contain references to each other if a connection is made in the inspector
        // I am not yet sure how to gain access to the instance of LocationNode that this even has triggered for.
    }
}