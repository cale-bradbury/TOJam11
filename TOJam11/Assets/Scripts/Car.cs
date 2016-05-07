﻿using UnityEngine;
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
    public float AP;
    public float maxAP;


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
        CarAction[] actions = GetComponentsInChildren<CarAction>();
        foreach (CarAction c in actions)
            if (c.ap <= AP)
                return true;
        return false;
    }
}
