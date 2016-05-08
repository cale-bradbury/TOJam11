using UnityEngine;
using System.Collections;

public class CarModifier : MonoBehaviour {

    protected Car car;
    protected LensToken token;

	void Start () {
        car = GetComponentInParent<Car>();
        if (car == null)
            car = GetComponent<Car>();
	}
	
	void OnDestroy () {
	    if(token!=null)
            token.Remove();
	}
}
