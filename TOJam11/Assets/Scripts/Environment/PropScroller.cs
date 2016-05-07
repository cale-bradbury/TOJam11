using UnityEngine;
using System.Collections;

public class PropScroller : MonoBehaviour {

    public float scrollSpeed = 0.75f;

    void Update()
    {
        Vector3 tempPos = transform.position;
        // float z = Mathf.Repeat(Time.time * scrollSpeed, 1);
        float z = Time.deltaTime * scrollSpeed;
        tempPos.z -= z;
        transform.position = tempPos;
    }
}
