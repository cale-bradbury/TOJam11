using UnityEngine;
using System.Collections;
using UnityEditor;

public class LocationNode : MonoBehaviour {
    //public Encounter encounter; whatever we decide events/battles/locations are, this can reference the one that is activated when a location is reached by the player.
    public GameObject[] ConnectedLocations;
    public GameObject connectionPrefab;
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
        GameObject[] locations = { gameObject, location };
        GameObject connection = Instantiate(connectionPrefab);
        connection.GetComponent<LocationConnection>().SetLocations(locations);
    }
}
