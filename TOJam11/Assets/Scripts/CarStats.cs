using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CarStats : MonoBehaviour {

    public Text nameText;
    public Text hpText;
    public Text apText;
    Scrollbar hpBar;
    Scrollbar apBar;

    CanvasRenderer[] renderers;
    float alpha
    {
        get { return renderers[0].GetAlpha(); }
        set
        {
            foreach (CanvasRenderer r in renderers)
                r.SetAlpha(value);
        }
    }
    float targetAlpha = 0;
    public float smoothing = .1f;

    void Start()
    {
        hpBar = hpText.GetComponentInChildren<Scrollbar>();
        apBar = apText.GetComponentInChildren<Scrollbar>();
        renderers = GetComponentsInChildren<CanvasRenderer>();
        alpha = 0;
    }

    public void ShowStats(Car car)
    {
        if (car == null)
        {
            targetAlpha = 0;
        }
        else
        {
            targetAlpha = 1;
            nameText.text = car.name;
            float hp = car.health.GetValue();
            hpText.text = "HP : " + hp;
            apText.text = "AP : " + car.AP;
            hpBar.size = hp / car.maxHealth.GetValue();
            apBar.size = car.AP / car.maxAP.GetValue();
        }
    }

    void Update()
    {
        alpha = Mathf.Lerp(alpha, targetAlpha, smoothing);
    }
}
