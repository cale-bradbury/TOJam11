using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class LocationNode : MonoBehaviour {
    [HideInInspector]
    public  List<LocationConnection> Connections = new List<LocationConnection>();
}
