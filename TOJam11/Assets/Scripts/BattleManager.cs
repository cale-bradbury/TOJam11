﻿using UnityEngine;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {
    public enum Turn
    {
        Player,
        Enemy,
        Enviroment
    }
    public Turn turn = Turn.Enemy;

    public static BattleManager instance;
    public Grid grid;
    public List<Car> enemyCars;
    public List<Car> playerCars;
    int index;
    public ButtonList list;
    CarStats stats;
    private Car _selected;
    public Car selected{
        get{return _selected;}
        set{
            _selected = value;
            DisplayMoves();
        }
    }

    public bool autoPlay = false;
    public GameObject selectedIcon;

	void Awake () {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
	}

    void Start()
    {
        stats = FindObjectOfType<CarStats>();
        Invoke("NextTurn", .5f);
    }

    void Update()
    {
        if(selected){
            selectedIcon.transform.position = selected.transform.position;
            selectedIcon.transform.localScale = Vector3.one;
        }
        else
        {
            selectedIcon.transform.localScale = Vector3.zero;
        }
    }
	
    public static void AddCar(Car c, int x, int y, bool isPlayer = true)
    {
        c.tile = instance.grid.GetTile(x,y);
        if(isPlayer)
            instance.playerCars.Add(c);
        else
            instance.enemyCars.Add(c);
	}

    public static void DestroyCar(Car c)
    {
        instance.enemyCars.Remove(c);
        instance.playerCars.Remove(c);
        Destroy(c.gameObject);
    }
    
    public void DisplayMoves()
    {
        stats.SetSelected(selected);
        list.Clear();
        list.Add("wait", () =>
        {
            grid.clickTimeout = .1f;
            selected.waiting = true;
            SelectCar();
        });
        CarAction[] actions = selected.GetComponentsInChildren<CarAction>();
        for (int i = 0; i < actions.Length; i++)
        {
            CarAction a = actions[i];
            if (selected.AP >= a.ap)
                list.Add(a.name, () =>
                {
                    grid.HideSelection();
                    grid.clickTimeout = .1f;
                    selected.AP -= a.ap;
                    list.Clear();
                    list.Add("cancel", () => { selected.AP += a.ap; SelectCar(selected);});
                    a.Perform(FinishedAction);
                });
        }
    }

    public void FinishedAction(){
        SelectCar();
    }

    public void SelectCar(Car tryToSelect = null)
    {
        grid.HideSelection();
        list.Clear();
        List<Car> cars = GetValidCars(turn == Turn.Enemy ? enemyCars : playerCars);
        if (cars.Count == 0)
        {
            NextTurn();
            return;
        }

        if (turn == Turn.Enemy||autoPlay)
        {
            CarAction[] actions = cars[0].GetComponentsInChildren<CarAction>();
            CarAction a = actions[Mathf.FloorToInt(Random.value * actions.Length)];
            cars[0].AP -= a.ap;
            selected = (cars[0]);
            a.PerformAI(FinishedAction);
        }
        else
        {
            List<GridTile> select = new List<GridTile>();
            for (int i = 0; i < cars.Count; i++)
            {
                select.Add(cars[i].tile);
            }
            if (tryToSelect != null && tryToSelect.CanSelect())
                selected = tryToSelect;
            else
                selected = cars[0];
            grid.ShowSelection(select, OnCarSelect, Color.white);            
        }
    }

    void OnCarSelect(GridTile tile)
    {
        selected = tile.car;
    }

    List<Car> GetValidCars(List<Car> cars)
    {
        List<Car> valid = new List<Car>();
        foreach (Car c in cars)
            if (c.HasEnoughAP()&&!c.waiting)
                valid.Add(c);
        return valid;
    }

    void NextTurn()
    {
        List<Car> cars = null;
        if (turn == Turn.Player){
            turn = Turn.Enemy;
            cars = enemyCars;
        }else if (turn == Turn.Enemy){
            turn = Turn.Player;
            cars = playerCars;
        }

        if (cars != null)
        {
            foreach (Car c in cars)
            {
                c.BroadcastMessage("BeginTurn", c);
            }
        }
        SelectCar();
    }
}
