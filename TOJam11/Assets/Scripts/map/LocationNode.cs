using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class LocationNode : MonoBehaviour {
    public string locationName;
    public string description;
    public bool isStart = false;
    [HideInInspector]
    public  List<LocationConnection> Connections = new List<LocationConnection>();
    private bool isScaledUp = false;

    void OnMouseOver()
    {        
        HandleClick();
        HandleHoverOver();
    }

    void OnMouseExit()
    {
        HandleClick();
        HandleHoverExit();
    }

    void HandleClick() {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }

    void HandleHoverOver()
    {
        if (!isScaledUp)
        {
            isScaledUp = true;
            transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
    }

    void HandleHoverExit()
    {
        if (isScaledUp)
        {
            isScaledUp = false;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
