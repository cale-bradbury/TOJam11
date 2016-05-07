using UnityEngine;
using System.Collections.Generic;

public class LocationNode : MonoBehaviour {
    public string locationName;
    public string description;
    public bool isStart = false;
    [HideInInspector]
    public  List<LocationConnection> Connections = new List<LocationConnection>();
    public PlayerNode playerNode = null;
    private Renderer rend = null;
    private Color activeColor = Color.green;
    private Color hoverColor = Color.cyan;
    private Color selectableColor = Color.white;
    private Color defaultColor = Color.grey;
    private bool isSelectable = false;       // Set to true if the player can move to this location.
    private bool isActive = false;           // Set to true if the player is at this location.
    private bool isScaledUp = false;

    void Start() {
        rend = GetComponent<Renderer>();
    }

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
        HandleHoverExit();
    }

    void HandleClick() {
        if (Input.GetMouseButtonDown(0) && playerNode != null)
        {
            playerNode.SetTargetLocation(this);
            transform.localScale = new Vector3(1f, 1f, 1f);
            isScaledUp = false;
            SetColor(activeColor);
        }
    }

    void HandleHoverOver()
    {
        if (!isScaledUp && isSelectable)
        {
            isScaledUp = true;
            transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            SetColor(hoverColor);
        }
    }

    void HandleHoverExit()
    {
        if (isScaledUp)
        {
            isScaledUp = false;
            transform.localScale = new Vector3(1f, 1f, 1f);
            SetColor(selectableColor);
        }
    }

    public void Activate() {
        isActive = true;
        SetColor(activeColor);
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
        if (val)
        {
            SetColor(Color.white);
        } else
        {
            SetColor(defaultColor);
        }
    }

    void SetColor(Color color)
    {
        rend.material.color = color;
    }
}
