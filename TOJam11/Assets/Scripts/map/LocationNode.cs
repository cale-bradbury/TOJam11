using UnityEngine;
using System.Collections.Generic;

public class LocationNode : MonoBehaviour {
    public string locationName;
    public string description;
    public bool isStart = false;
    [HideInInspector]
    public  List<LocationConnection> Connections = new List<LocationConnection>();
    public PlayerNode playerNode = null;
    private bool isSelectable = false;       // Set to true if the player can move to this location.
    private bool isActive = false;           // Set to true if the player is at this location.
    private bool isScaledUp = false;

    void OnMouseOver()
    {       
        if(isSelectable)
        {
            HandleClick();
            HandleHoverOver();
        }        
    }

    void OnMouseExit()
    {
        HandleClick();
        HandleHoverExit();
    }

    void HandleClick() {
        if (Input.GetMouseButtonDown(0) && playerNode != null)
        {
            playerNode.SetTargetLocation(this);
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

    public void Activate() {
        isActive = true;
        for(var i = 0; i < Connections.Count; i++)
        {
            Connections[i].GetOther(this).SetSelectability(true);
        }
    }

    public void Reset() {
        isActive = false;
        SetSelectability(false);
    }

    public void SetSelectability(bool val)
    {
        isSelectable = val;
        // change appearance based on new value
    }
}
