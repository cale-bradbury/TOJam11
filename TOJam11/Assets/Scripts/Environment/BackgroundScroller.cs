using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {
    public float scrollSpeed = 0.75f;
    private Vector2 savedOffset;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        savedOffset = rend.sharedMaterial.GetTextureOffset("_MainTex");

    }

    void Update()
    {
        float y = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(savedOffset.x, y);
        rend.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable()
    {
        rend.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}
