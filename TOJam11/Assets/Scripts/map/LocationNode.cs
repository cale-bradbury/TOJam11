using UnityEngine;
using System.Collections;
using UnityEditor;

public class LocationNode : MonoBehaviour {
    public GameObject[] ConnectedLocations;
    public GameObject[] Connections;

    void Start () {
        ConnectToAllLocations();
	}

    void ConnectToAllLocations() {
        foreach (GameObject location in ConnectedLocations) {
            ConnectToLocation(location);
        }
    }

    void ConnectToLocation(GameObject location) {

        // create a new game object
            // attach a line renderer
            // set the points of the line renderer to connect this transform with location's transform

    }
}
