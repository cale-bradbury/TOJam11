using UnityEngine;
using System.Collections;

public class CarAction : MonoBehaviour {
    
    [HideInInspector]
    public Car car;
    public string name;
    public delegate void ActionCallback();
    public ActionCallback finishedAction;
    public int ap = 1;

    virtual public void Start()
    {
        car = GetComponentInParent<Car>();
    }

    virtual public void Perform(ActionCallback callback)
    {
        finishedAction = callback;
        //to be overridden
    }

    virtual public void PerformAI(ActionCallback callback)
    {
        finishedAction = callback;
    }

    public void EndTurn()
    {
        finishedAction();
    }
}
