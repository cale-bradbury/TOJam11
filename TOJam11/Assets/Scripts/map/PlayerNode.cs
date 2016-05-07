using UnityEngine;
using System.Collections;

public class PlayerNode : MonoBehaviour {
    public float moveSpeed = 1;
    [HideInInspector]
    public MapController map = null;
    private LocationNode targetLocation = null;
    private LocationNode currentLocation = null;

    void FixedUpdate() {
        MoveToLocation();
    }
    
    void MoveToLocation()
    {
        if (targetLocation != null) {
            float distance = Vector3.Distance(transform.position, targetLocation.transform.position);
            float speed = moveSpeed / 100 / Mathf.Sqrt(distance);
            transform.position = Vector3.Lerp(transform.position, targetLocation.transform.position, speed);
            if(distance < 0.05f)
            {
                SetLocation(targetLocation);
                
            }            
        }
    }

    public void SetTargetLocation(LocationNode node)
    {
        targetLocation = node;
    }

    public void SetLocation(LocationNode node) {
        targetLocation = null;
        transform.position = node.transform.position;
        currentLocation = node;
        map.ActiveLocation(node);
    }
}
