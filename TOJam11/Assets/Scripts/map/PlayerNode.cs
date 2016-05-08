using UnityEngine;
using System.Collections;

public class PlayerNode : MonoBehaviour {
    public float moveSpeed = 1;
    [HideInInspector]
    public MapController map = null;
    private LocationNode targetLocation = null;
    private float targetHalfwayDistance = 0f;
    private LocationNode currentLocation = null;

    void FixedUpdate() {
        if (!map.isPaused)
        {
            MoveToLocation();
        }
    }
    
    void MoveToLocation()
    {
        if (targetLocation != null) {
            float distance = Vector3.Distance(transform.position, targetLocation.transform.position);
            float speed = moveSpeed / 100 / Mathf.Sqrt(distance);
            transform.position = Vector3.Lerp(transform.position, targetLocation.transform.position, speed);

            if(distance < targetHalfwayDistance)
            {
                // check for encounter
                targetLocation.RandomEncounter();
                targetHalfwayDistance = 0f;
            }

            if(distance < 0.05f)
            {
                SetLocation(targetLocation);
                currentLocation.StartEncounter();
            }            
        }
    }

    public void SetTargetLocation(LocationNode node)
    {
        map.ResetLocations();
        targetLocation = node;
        targetHalfwayDistance = Vector3.Distance(transform.position, node.transform.position) / 2;
    }

    public void SetLocation(LocationNode node) {
        targetLocation = null;
        transform.position = node.transform.position;
        currentLocation = node;
        map.ActiveLocation(node);
    }
}
