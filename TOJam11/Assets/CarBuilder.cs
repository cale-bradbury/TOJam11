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
        
	}

    public void SetSocket(Socket socket)
    {
        activeSocket = socket;
        cycleModules = inventory.GetModulesOfType(activeSocket.type);
    }
    
    public void CycleSocket(){
        socketIndex++;
        socketIndex %= activeSocket.parent.sockets.Length;
        activeSocket = activeSocket.parent.sockets[socketIndex];
        cycleModules = inventory.GetModulesOfType(activeSocket.type);
    }

    public void CycleModule()
    {
        cycleIndex++;
        cycleIndex %= cycleModules.Length;
        Module m = Instantiate<Module>(cycleModules[cycleIndex]);
        m.Scan();
        m.AddToSocket(activeSocket);
    }
}
