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

    bool mouseDown = false;
    Material mat;
    public Color targetColor = Color.white;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        mat.color = targetColor;
    }

    void Update()
    {
        if (hovering)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mouseDown = true;
                targetColor = Color.cyan;
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
        targetColor = Color.red;
        hovering = true;
    }

    void OnMouseExit()
    {
        targetColor = Color.white;
        hovering = false;
    }
	
}
