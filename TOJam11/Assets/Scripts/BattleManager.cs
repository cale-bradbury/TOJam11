using UnityEngine;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {
    public enum Turn
    {
        Player,
        Enemy,
        Enviroment
    }
    public Turn turn;

    public static BattleManager instance;
    public Grid grid;
    public List<Car> enemyCars;
    public List<Car> playerCars;
    int index;
    public ButtonList list;

	// Use this for initialization
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
        SelectCar();
    }
	
	// Update is called once per frame
    public static void AddCar(Car c, int x, int y, bool isPlayer = true)
    {
        c.tile = instance.grid.GetTile(x,y);
        if(isPlayer)
            instance.playerCars.Add(c);
        else
            instance.enemyCars.Add(c);
	}

    public void DisplayMoves(Car c)
    {
        list.Clear();
        CarAction[] actions = c.GetComponentsInChildren<CarAction>();
        for (int i = 0; i < actions.Length; i++)
        {
            CarAction a = actions[i];
            if (c.AP >= a.ap)
                list.Add(a.name, () => { 
                    grid.clickTimeout = .1f;
                    c.AP -= a.ap; 
                    a.Perform(FinishedAction); 
                });
        }
    }

    public void FinishedAction(){
        instance.grid.HideSelection();
        SelectCar();
    }

    public void SelectCar()
    {
        list.Clear();
        for (int i = 0; i < playerCars.Count; i++)
        {
            Car c = playerCars[i];
            if(c.HasEnoughAP())
                list.Add(c.name, () => { DisplayMoves(c); });
        }
        if (list.Length == 0)
            NextTurn();
    }

    void NextTurn()
    {
        if (turn == Turn.Player)
            turn = Turn.Enemy;
        else if (turn == Turn.Enemy)
            turn = Turn.Player;

    }
}
