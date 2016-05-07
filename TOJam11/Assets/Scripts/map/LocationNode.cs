using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class LocationNode : MonoBehaviour {
    //public Encounter encounter; whatever we decide events/battles/locations are, this can reference the one that is activated when a location is reached by the player.
    public GameObject[] ConnectedLocations;
    public GameObject connectionPrefab;
    private GameObject[] Connections;

    void Awake()
    {
        // set the length to equal length of ConnectedLocations
        Connections = new GameObject[ConnectedLocations.Length];
    }

    void Start () {
        ConnectToAllLocations();
	}

    void ConnectToAllLocations() {
        foreach (GameObject location in ConnectedLocations) {
            ConnectToLocation(location);
        }
    }

    void ConnectToLocation(GameObject location) {
        GameObject connection = null;
        LocationNode otherLocation = location.GetComponent<LocationNode>();
        bool requiresConnection = !HasConnectionFor(location);
        bool otherRequiresConnection = !otherLocation.HasConnectionFor(gameObject);
        bool requiresNewConnection = requiresConnection && otherRequiresConnection;
        int connectionIndex = Utils.FindInArray(ConnectedLocations, location);

        // If neither gameObject has a connection reference for this pair of linked locations, createa a new one
        if (requiresNewConnection) {
            GameObject[] locations = { gameObject, location };
            connection = Instantiate(connectionPrefab);
            connection.GetComponent<LocationConnection>().SetLocations(locations);
        }

        // Store a reference to new connection, or...
        if (requiresConnection)
        {
            // If no new connection, use the other locations'
            if (connection == null)
            {
                
                connection = otherLocation.GetConnectionFor(gameObject);
            }
            
            SetConnection(connection, GetConnectedLocationIndex(location));
        }       
    }

    public void SetConnection(GameObject connection, int index)
    {
        Connections[index] = connection;
    }

    public GameObject GetConnectionFor(GameObject location)
    {
        int index = GetConnectedLocationIndex(location);
        return Connections[index];
    }

    public bool HasConnectionFor(GameObject location)
    {
        int index = GetConnectedLocationIndex(location);
        return HasConnectionAt(index);
    }

    public int GetConnectedLocationIndex(GameObject location) {
        return Utils.FindInArray(ConnectedLocations, location);
    }

    public bool HasConnectionAt(int index)
    {
        return Connections[index] is GameObject;
    }
}
