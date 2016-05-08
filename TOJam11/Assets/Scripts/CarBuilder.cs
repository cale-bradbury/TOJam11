using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class CarBuilder : MonoBehaviour {

    public Inventory inventory;
    public Car car;
    public GameObject emptyCarPrefab;
    public Socket activeSocket;
    [HideInInspector]
    public Module[] cycleModules;
    [HideInInspector]
    public int cycleIndex = 0;
    int socketIndex = 0;    

	// Use this for initialization
	void Start () {
        
	}

    public void SetSocket(Socket socket)
    {
        activeSocket = socket;
        cycleModules = inventory.GetModulesOfType(activeSocket.type);
        if (socket.child)
        {
            cycleIndex = 0;
            for(int i = 0; i<cycleModules.Length;i++){
                if (socket.child.name == cycleModules[i].name)
                {
                    cycleIndex = i;
                    return;
                }
            }
        }
    }

    public void SelectSocket(int i)
    {
        socketIndex = i;
        socketIndex %= activeSocket.parent.sockets.Length;
        activeSocket = activeSocket.parent.sockets[socketIndex];
        cycleModules = inventory.GetModulesOfType(activeSocket.type);
    }
    public void CycleSocket()
    {
        SelectSocket(socketIndex + 1);
    }
    
    public void SelectModule(int i)
    {
        cycleIndex = i;
        cycleIndex %= cycleModules.Length;
        Module m = Instantiate<Module>(cycleModules[cycleIndex]);
        m.Scan();
        m.AddToSocket(activeSocket);
    }
    public void CycleModule()
    {
        SelectModule(cycleIndex + 1);
    }
}
