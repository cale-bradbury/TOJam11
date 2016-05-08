using UnityEngine;
using System.Collections;

public class CarAction : MonoBehaviour {
    
    [HideInInspector]
    public Car car;
    public string name;
    public delegate void ActionCallback();
    public ActionCallback finishedAction;
    public int ap = 1;
    [HideInInspector]
    public bool canCancel = false;

    virtual public void Start()
    {
        car = GetComponentInParent<Car>();
    }

    virtual public void Perform(ActionCallback callback)
    {
        finishedAction = callback;
        //to be overridden
    }

    //return false if it's fucking dumb for the ai to do this action
    virtual public bool PerformAI(ActionCallback callback)
    {
        finishedAction = callback;
        return true;
    }

    public void EndTurn()
    {
        finishedAction();
    }
}
