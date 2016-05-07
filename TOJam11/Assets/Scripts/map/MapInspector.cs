using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(LocationNode))]
public class MapInspector : Editor
{
    public override void OnInspectorGUI()
    {        
        LocationNode node = target as LocationNode;
        //GameObject[] locationsBefore = node.ConnectedLocations.Clone() as GameObject[];
        List<GameObject> locationsBefore = new List<GameObject>(node.ConnectedLocations);
        base.OnInspectorGUI();
        //bool changed = !ArrayUtils.AreEqual(node.ConnectedLocations, locationsBefore);
        bool changed = Utils.CompareLists<GameObject>(node.ConnectedLocations, locationsBefore);


        if (changed)
        {
            // if there was a change, make sure each location linked to by this one is linking it back (do not duplicate references!)
            Debug.Log("A value was changed!");
            node.SyncConnectedLocations();
        }        
    }
}