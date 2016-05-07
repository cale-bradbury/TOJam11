using UnityEngine;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {
    public static BattleManager instance;
    public Grid grid;
    public List<Car> cars;
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
	
	// Update is called once per frame
    public static void AddCar(Car c, int x, int y)
    {
        Debug.Log(c);
        c.tile = instance.grid.GetTile(x,y);
        instance.cars.Add(c);
        Next();
	}

    public static void Next()
    {
        instance.grid.HideSelection();
        instance.index++;
        instance.index %= instance.cars.Count;
        Car c = instance.cars[instance.index];
        instance.DisplayMoves(c);
    }

    public void DisplayMoves(Car c)
    {
        list.Clear();
        CarAction[] actions = c.GetComponentsInChildren<CarAction>();
        Debug.Log(actions.Length);
        for (int i = 0; i < actions.Length; i++)
        {
            CarAction a = actions[i];
            list.Add(actions[i].name, () => { grid.clickTimeout = .1f; a.Perform(); });
        }
    }
}
