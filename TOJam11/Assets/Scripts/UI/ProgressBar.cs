using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour {

    public float max = 100f;
    public float min = 0f;
    public float progress = 0f;
    public GameObject bar;
    private RectTransform barRect;
    private RectTransform rect;
    private float barHeightRatio = 0.6f;
    private float barWidthRatio = 0.95f;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        barRect = bar.GetComponent<RectTransform>();
    }

    public void Redraw()
    {
        Vector2 parentSize = rect.sizeDelta;
        Vector2 size = new Vector2(Mathf.Abs(parentSize.x) * barWidthRatio, parentSize.y * barHeightRatio);
        size.x = size.x * ((progress - min) / max);
        barRect.sizeDelta = size;
        barRect.localPosition = new Vector3(Mathf.Abs(parentSize.x*.5f) * (1 - barWidthRatio)-parentSize.x*.5f, 0,0);
    }
}
