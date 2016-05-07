using UnityEngine;
using System.Collections;

public class LocationConnection : MonoBehaviour
{
    public LocationNode nodeA;
    public LocationNode nodeB;
    private LineRenderer line;
	
    public void SetPositions()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.SetPosition(0, nodeA.transform.position);
        line.SetPosition(1, nodeB.transform.position);  
    }

    public LocationNode GetOther(LocationNode n)
    {
        if (n == nodeA)
            return nodeB;
        if (n == nodeB)
            return nodeA;
        return null;
    }
}
