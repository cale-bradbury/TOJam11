using UnityEngine;
using System.Collections;

public class GridTile : MonoBehaviour {

    [HideInInspector]
    public Grid grid;
    [HideInInspector]
    public bool hovering = false;
    [HideInInspector]
    public int x;
    [HideInInspector]
    public int y;

    public Car car
    {
        get { return grid.grid[x, y]; }
        set { grid.grid[x, y] = value; }
    }

    bool mouseDown = false;
    Material mat;
    public Color color = Color.white;
    Color targetColor = Color.white;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        mat.color = targetColor;
    }

    void Update()
    {
        targetColor = color;
        if (hovering)
        {
            targetColor = Color.cyan;
            if (Input.GetMouseButtonDown(0))
            {
                mouseDown = true;
                targetColor = Color.blue;
            }
            else if (mouseDown && Input.GetMouseButtonUp(0))
            {
                grid.Click(this);
            }
        }
        mat.color = Color.Lerp(mat.color, targetColor, .5f);
    }

    void OnMouseEnter()
    {
        hovering = true;
    }

    void OnMouseExit()
    {
        hovering = false;
    }
	
}
