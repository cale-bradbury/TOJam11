using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CarBuilder : MonoBehaviour {

    public Inventory inventory;
    public Car car;
    public GameObject emptyCarPrefab;
    public Socket activeSocket;
    Module[] cycleModules;
    int cycleIndex = 0;
    int socketIndex = 0;    

	// Use this for initialization
	void Start () {
        cycleModules = inventory.GetModulesOfType(activeSocket.type);
	}
    
    void CycleSocket(){
        socketIndex++;
        socketIndex %= activeSocket.parent.sockets.Length;
        activeSocket = activeSocket.parent.sockets[socketIndex];
        cycleModules = inventory.GetModulesOfType(activeSocket.type);
    }

    void CycleModule()
    {
        cycleIndex++;
        cycleIndex %= cycleModules.Length;
        Module m = Instantiate<Module>(cycleModules[cycleIndex]);
        m.AddToSocket(activeSocket);
    }
}
