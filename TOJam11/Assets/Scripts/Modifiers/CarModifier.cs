using UnityEngine;
using System.Collections;

public class CarModifier : MonoBehaviour {

    protected Car car;
    protected LensToken token;

	// Use this for initialization
	void Awake () {
        GetComponentInParent<Car>();
	}
	
	// Update is called once per frame
	void OnDestroy () {
	    if(token!=null)
            token.Remove();
	}
}
