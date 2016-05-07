using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {

    public Vector2 gridSize;
    public float unitSize = 1;
    public Car[,] grid;

    public GameObject gridTilePrefab;
    GridTile[,] gridTiles;
    List<GridTile> selection;
    public delegate void GridClick(GridTile tile);
    GridClick selectionCallback;
    [HideInInspector]
    public float clickTimeout;

	// Use this for initialization
    void Awake()
    {
        grid = ArrayUtils.Create2D<Car>((Car)null, Mathf.FloorToInt(gridSize.x), Mathf.FloorToInt(gridSize.y));
        gridTiles = ArrayUtils.Create2D<GridTile>(AddTile, Mathf.FloorToInt(gridSize.x), Mathf.FloorToInt(gridSize.y));
   	}

    public GridTile GetTile(int x, int y)
    {
        return gridTiles[x, y];
    }

    GridTile AddTile(int x, int y)
    {
        GameObject g = Instantiate<GameObject>(gridTilePrefab);
        g.transform.parent = transform;
        g.transform.localPosition = new Vector3(x,0,y) * unitSize;
        GridTile t = g.GetComponent<GridTile>();
        t.grid = this;
        t.x = x;
        t.y = y;
        return t;
    }

    void Update()
    {
        if (clickTimeout > 0)
            clickTimeout -= Time.deltaTime;
    }

    public void Click(GridTile tile)
    {
        if (clickTimeout > 0)
            return;
        if (selection != null && selection.IndexOf(tile)!=-1)
        {
            selection = null;
            selectionCallback(tile);
            selectionCallback = null;
        }
    }

    public void ShowSelection(List<GridTile> tiles, GridClick callback)
    {
        selection = tiles;
        ColorSelection(tiles, Color.green);
        selectionCallback = callback;
    }

    public void ColorSelection(List<GridTile> tiles, Color c)
    {
        foreach (GridTile g in tiles)
        {
            g.color = c;
        }
    }

    public void HideSelection()
    {
        for (int i = 0; i < gridTiles.GetLength(0); i++)
        {
            for (int j = 0; j < gridTiles.GetLength(1); j++)
            {
                gridTiles[i, j].color = Color.white;
            }
        }
    }

    public List<GridTile> GetSuroundingDiamond(GridTile tile, int dist)
    {
        List<GridTile> tiles = new List<GridTile>();
        for (int i = -dist; i <= dist; i++)
        {
            for (int j = -dist + Mathf.Abs(i); j <= dist - Mathf.Abs(i); j++)
            {
                int n = i + tile.x;
                int m = j + tile.y;
                if (n > -1 && n < gridTiles.GetLength(0) && m > -1 && m < gridTiles.GetLength(1))
                tiles.Add(gridTiles[n,m]);
            }
        }
        return tiles;
    }
    public List<GridTile> GetSuroundingSquare(GridTile tile, int dist)
    {
        List<GridTile> tiles = new List<GridTile>();
        for (int i = Mathf.Max(0, tile.x - dist); i < Mathf.Min(gridTiles.GetLength(0), tile.x + dist + 1); i++)
        {
            for (int j = Mathf.Max(0, tile.y - dist); j < Mathf.Min(gridTiles.GetLength(1), tile.y + dist + 1); j++)
            {
                tiles.Add(gridTiles[i, j]);
            }
        }
        return tiles;
    }

    public List<GridTile> GetSuroundingDistance(GridTile tile, int dist)
    {
        List<GridTile> tiles = new List<GridTile>();
        for (int i = 0; i < gridTiles.GetLength(0); i++)
        {
            for (int j = 0; j < gridTiles.GetLength(1); j++)
            {
                if(Vector3.Distance(gridTiles[i, j].transform.position, tile.transform.position)<dist*unitSize)
                    tiles.Add(gridTiles[i, j]);
            }
        }
        return tiles;
    }

    public GridTile GetRandom()
    {
        return gridTiles[Mathf.FloorToInt(Random.value*gridTiles.GetLength(0)), Mathf.FloorToInt(Random.value*gridTiles.GetLength(1))];
    }

    public void RemoveCarTiles(List<GridTile> g)
    {
        for (int i = g.Count - 1; i >= 0; i--)
        {
            if (g[i].car != null)
                g.RemoveAt(i);
        }
    }
    public void RemoveEmptyTiles(List<GridTile> g)
    {
        for (int i = g.Count - 1; i >= 0; i--)
        {
            if (g[i].car == null)
                g.RemoveAt(i);
        }
    }
	
}
