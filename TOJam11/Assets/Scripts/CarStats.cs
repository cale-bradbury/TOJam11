using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CarStats : CanvasFadeElement {

    public Text nameText;
    public Text hpText;
    public Text apText;
    Scrollbar hpBar;
    Scrollbar apBar;
    Car last;

    override protected void Start()
    {
        base.Start();
        hpBar = hpText.GetComponentInChildren<Scrollbar>();
        apBar = apText.GetComponentInChildren<Scrollbar>();
    }

    public void ShowStats(Car car)
    {
        if (car != null)
        {
            Show();
            nameText.text = car.name;
            float hp = car.health.GetValue();
            hpText.text = "HP : " + hp;
            apText.text = "AP : " + car.AP;
            hpBar.size = hp / car.maxHealth.GetValue();
            apBar.size = car.AP / car.maxAP.GetValue();
        }
        else if(last!=null)
        {
            Hide();
        }
        last = car;
    }
}
