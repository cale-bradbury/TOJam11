using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour {

    public float maxProgress = 100f;
    public float minProgress = 0f;
    public float currentProgress = 0f;
    public GameObject bar;
    private RectTransform barRect;
    private RectTransform rect;
    private float barHeightRatio = 0.6f;
    private float barWidthRatio = 0.92f;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        barRect = bar.GetComponent<RectTransform>();
        UpdateBar();
    }

    void UpdateBar()
    {
        Debug.Log(rect.sizeDelta);
        Vector2 parentSize = rect.sizeDelta;
        Vector2 size = new Vector2(parentSize.x * barWidthRatio, parentSize.y * barHeightRatio);
        size.x = size.x * ((currentProgress - minProgress) / maxProgress);
        barRect.sizeDelta = size;
    }
}
