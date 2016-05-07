using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridScript : MonoBehaviour {

    public Vector2 gridSize;
    public float unitSize = 1;
    public GameObject[,] grid;

    public GameObject gridTilePrefab;
    GridTile[,] gridTiles;


	// Use this for initialization
    void Start()
    {
        grid = ArrayUtils.Create2D<GameObject>((GameObject)null, Mathf.FloorToInt(gridSize.x), Mathf.FloorToInt(gridSize.y));
        gridTiles = ArrayUtils.Create2D<GridTile>(AddTile, Mathf.FloorToInt(gridSize.x), Mathf.FloorToInt(gridSize.y));
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

    public void Click(GridTile tile)
    {
        List<GridTile> tiles = GetSuroundingDiamond(tile, 3);
        foreach (GridTile t in tiles)
        {
            t.targetColor = Color.green;
            t.Invoke("OnMouseExit", 1);
        }
    }

    List<GridTile> GetSuroundingDiamond(GridTile tile, int dist)
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
    List<GridTile> GetSuroundingSquare(GridTile tile, int dist)
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

    List<GridTile> GetSuroundingDistance(GridTile tile, int dist)
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
	
}
