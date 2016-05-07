using UnityEngine;
using System.Collections;

public class PlayerNode : MonoBehaviour {
    public float moveSpeed = 1;
    private LocationNode targetLocation = null;
    private LocationNode currentLocation = null;

    void FixedUpdate() {
        MoveToLocation();
    }
    
    void MoveToLocation()
    {
        if (targetLocation != null) {
            float distance = Vector3.Distance(transform.position, targetLocation.transform.position);
            //float speed = moveSpeed / 100 / Mathf.Sqrt(distance);
            //transform.position = Vector3.Lerp(transform.position, targetLocation.transform.position, speed);
            transform.position = Vector3.MoveTowards(transform.position, targetLocation.transform.position, moveSpeed / 100);
            if(distance < 0.05f)
            {
                SetLocation(targetLocation);
            }
            
        }

        // animate along location connection
        // activate location connection
        // there could be a random encounter here
    }

    public void SetTargetLocation(LocationNode node)
    {
        targetLocation = node;
    }

    public void SetLocation(LocationNode node) {
        targetLocation = null;
        transform.position = node.transform.position;
        currentLocation = node;
    }
}
