using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CarStats : MonoBehaviour
{

    public Text nameText;
    public Text hpText;
    public Text apText;
    ProgressBar hpBar;
    ProgressBar apBar;
    Car selected;

    void Start()
    {
        hpBar = hpText.GetComponentInChildren<ProgressBar>();
        apBar = apText.GetComponentInChildren<ProgressBar>();
    }

    public void SetSelected(Car car)
    {
        selected = car;
        ShowStats(car);
    }

    public void ShowStats(Car car)
    {
        if (car != null)
        {
            nameText.text = car.name;
            float hp = car.health.GetValue();
            hpText.text = "HP : " + hp;
            apText.text = "AP : " + car.AP;
            hpBar.max = car.maxHealth.GetValue();
            hpBar.progress = hp;
            apBar.max = car.maxAP.GetValue();
            apBar.progress = car.AP;
            hpBar.Redraw();
            apBar.Redraw();
        }
        else if(selected!=null)
        {
            ShowStats(selected);
        }
    }
}
