using UnityEngine;
using System.Collections;

public class LocationConnection : MonoBehaviour {
    public GameObject[] locations;
    private LineRenderer line;
	

	void Awake () {
        line = gameObject.GetComponent<LineRenderer>();
        SetPositions();
	}

    public void SetLocations(GameObject[] newLocations)
    {
        locations = newLocations;
        SetPositions();
    }

    void SetPositions()
    {
        for (int i = 0; i < locations.Length; i++)
        {
            if (locations[i])
            {
                line.SetPosition(i, locations[i].transform.position);
            }
        }   
    }
}
