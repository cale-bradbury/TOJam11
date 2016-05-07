using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

    private GridTile _tile;
    public GridTile tile
    {
        get { return _tile; }
        set
        {
            if (_tile != value)
            {
                MoveTile(value);
            }
        }
    }

    public bool isPlayer;
    public float AP = 0;
    public CarAction[] actions;

    public LensedValue<float> health;
    public LensedValue<float> maxHealth;
    public LensedValue<float> maxAP;
    public LensedValue<float> turnAP;

    void Awake()
    {
        health = new LensedValue<float>(0);
        maxHealth = new LensedValue<float>(0);
        health.AddLens(new Lens<float>(int.MaxValue, (x) => Mathf.Max(x, maxHealth.GetValue())));
        maxAP = new LensedValue<float>(0);
        turnAP = new LensedValue<float>(0);
    }

    void MoveTile(GridTile t)
    {
        if(_tile!=null)
            _tile.car = null;
        transform.parent = t.transform;
        t.car = this;
        _tile = t;
	}
	
	// Update is called once per frame
	void Update () {

        transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, .1f); ;
	}

    public bool HasEnoughAP()
    {
        actions = GetComponentsInChildren<CarAction>();
        foreach (CarAction c in actions)
            if (c.ap <= AP)
                return true;
        return false;
    }

    void BeginTurn(Car c)
    {
        AP += turnAP.GetValue();
        AP = Mathf.Max(AP, maxAP.GetValue());
    }
}
