using UnityEngine;
using System.Collections;

public class CarLoader : MonoBehaviour {

    public GameObject[] cars;
    Grid grid;
    public bool isPlayer = true;


	// Use this for initialization
	void Start () {
        grid = FindObjectOfType<Grid>();
        for (int i = 0; i < cars.Length; i++ )
            GetTile(cars[i]);
	}

    void GetTile(GameObject prefab)
    {
        GridTile g = grid.GetRandom();
        if (g.car != null)
        {
            GetTile(prefab);
            return;
        }

        Car c = Instantiate<GameObject>(prefab).GetComponent<Car>();
        BattleManager.AddCar(c, g.x,g.y, isPlayer);
    }
	
}
