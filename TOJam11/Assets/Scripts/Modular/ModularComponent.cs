using UnityEngine;
using System.Collections.Generic;

public enum ModularType
{
    Chasis,
    Wheel,
    Body,
    Gun
}

public class ModularComponent : MonoBehaviour {

    public ModularType type;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	} 
}
