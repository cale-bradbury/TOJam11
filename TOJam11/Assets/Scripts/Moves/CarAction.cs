using UnityEngine;
using System.Collections;

public class CarAction : MonoBehaviour {

    [HideInInspector]
    public Car car;
    public string name;

    void Start()
    {
        car = GetComponentInParent<Car>();
    }

    virtual public void Perform()
    {
        //to be overridden
    }
}
