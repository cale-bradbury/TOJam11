using UnityEngine;
using System.Collections;

public class CarModifier : MonoBehaviour {

    protected Car car;
    protected LensToken token;

	// Use this for initialization
	void Awake () {
        car = GetComponentInParent<Car>();
        if (car == null)
            car = car = GetComponent<Car>();
	}
	
	// Update is called once per frame
	void OnDestroy () {
	    if(token!=null)
            token.Remove();
	}
}
