using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CarStats : MonoBehaviour
{

    public Text nameText;
    public Text hpText;
    public Text apText;
    Scrollbar hpBar;
    Scrollbar apBar;
    Car selected;

    void Start()
    {
        hpBar = hpText.GetComponentInChildren<Scrollbar>();
        apBar = apText.GetComponentInChildren<Scrollbar>();
    }

    public void SetSelected(Car car)
    {
        selected = car;
    }

    public void ShowStats(Car car)
    {
        if (car != null)
        {
            nameText.text = car.name;
            float hp = car.health.GetValue();
            hpText.text = "HP : " + hp;
            apText.text = "AP : " + car.AP;
            hpBar.size = hp / car.maxHealth.GetValue();
            apBar.size = car.AP / car.maxAP.GetValue();
        }
        else if(selected!=null)
        {
            ShowStats(selected);
        }
    }
}
