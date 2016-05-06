using UnityEngine;
using System.Collections;

public class LocationConnection : MonoBehaviour {
    public GameObject[] locations;
    private LineRenderer line;
	

	void Start () {
        line = gameObject.GetComponent<LineRenderer>();
        SetPositions();
	}

    void SetPositions()
    {
        for (int i = 0; i < locations.Length; i++)
        {
            //line.Positions[i] = locations[i].transform.position;
            line.SetPosition(i, locations[i].transform.position);
        }
    }
}
