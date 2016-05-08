using UnityEngine;
using System.Collections;

public class Module : MonoBehaviour
{
    public enum Types
    {
        Vehicle,

        Chassis,
        Engine,
        Wheel,
        Driver,
        Passesnger,

        Head,
        Shirt,
        Pants,
        Accessory,
    }

    public Types type;
    public string name;
    public string description;
    [HideInInspector]
    public int count;
    [HideInInspector]
    public Socket[] sockets;
    [HideInInspector]
    public Socket parent;

    void Start()
    {
        Scan();
    }

    public void Scan()
    {
        sockets = GetComponentsInChildren<Socket>();
        foreach (Socket s in sockets)
            s.parent = this;
    }

    public void AddToSocket(Socket add)
    {
        if(add.child==this)
            return;
        if (add.child != null)
        {
            foreach (Socket s in add.child.sockets)
            {
                if (s.child != null)
                {
                    Socket empty = FindEmptySocket(s.type);
                    if (empty != null)
                    {
                        empty.SetChild(s.child);
                    }
                }
            }
        }
        add.SetChild(this);
    }

    public Socket FindEmptySocket(Types type)
    {
        for (int i = 0; i < sockets.Length; i++)
        {
            if (sockets[i].type == type && sockets[i].child == null)
                return sockets[i];
        }
        return null;
    }
}
