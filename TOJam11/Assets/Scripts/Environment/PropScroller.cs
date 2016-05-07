using UnityEngine;
using System.Collections;

public class PropScroller : MonoBehaviour {

    public float scrollSpeed = 10f;

    void Update()
    {
        Vector3 tempPos = transform.position;
        float z = Time.deltaTime * scrollSpeed;
        tempPos.z -= z;
        transform.position = tempPos;
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}