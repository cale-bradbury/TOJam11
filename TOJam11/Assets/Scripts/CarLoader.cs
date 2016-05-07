using UnityEngine;
using System.Collections;

public class CarLoader : MonoBehaviour {

    public GameObject car;
    Grid grid;
    public bool isPlayer = true;


	// Use this for initialization
	void Start () {
        grid = FindObjectOfType<Grid>();
        GetTile();
	}

    void GetTile()
    {
        GridTile g = grid.GetRandom();
        if (g.car != null)
        {
            GetTile();
            return;
        }

        Car c = Instantiate<GameObject>(car).GetComponent<Car>();
        BattleManager.AddCar(c, g.x,g.y, isPlayer);
    }
	
}
