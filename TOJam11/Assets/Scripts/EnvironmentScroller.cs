using UnityEngine;
using System.Collections;

public class EnvironmentScroller : MonoBehaviour {

    public GameObject propsParent;
    public GameObject background;
    private Renderer bgRenderer;

    public float scrollSpeed = 0.75f;
    private Vector2 savedOffset;

    void Start()
    {
        bgRenderer = background.GetComponent<Renderer>();
        savedOffset = bgRenderer.sharedMaterial.GetTextureOffset("_MainTex");

    }

    void Update()
    {
        float y = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(savedOffset.x, y);
        bgRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable()
    {
        bgRenderer.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}
