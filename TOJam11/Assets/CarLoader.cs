using UnityEngine;
using System.Collections;

public class CarLoader : MonoBehaviour {

    public GameObject car;
    Grid grid;


	// Use this for initialization
	void Start () {
        grid = FindObjectOfType<Grid>();
        grid.AddCar(car,1,1);
	}
	
	// Update is called once per frame
	void NextTurn () {
	    
	}
}
