using UnityEngine;
using System.Collections;

public class ArrayUtils 
{
	public static T[,,] Create3D<T>(T fill,int x, int y, int z){
		T[,,] a = new T[x,y,z];
		for(int i = 0; i<x;i++){
			for(int j = 0; j<y;j++){
				for(int k = 0; k<z;k++){
					a[i,j,k] = fill;
				}
			}
		}
		return a;
	}
    public static T[,] Create2D<T>(T fill, int x, int y)
    {
        T[,] a = new T[x, y];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                a[i, j] = fill;
            }
        }
        return a;
    }
    
    public static T[,] Create2D<T>(System.Func<int,int,T> func, int x, int y)
    {
        T[,] a = new T[x, y];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                a[i, j] = func(i,j);
            }
        }
        return a;
    }

    public static T[, ,] Clone3D<T>(T[, ,] a)
    {
		return a.Clone() as T[,,];
	}

    public static T[, ,] Merge3D<T>(T[, ,] parent, T[, ,] child, int x, int y, int z)
    {
		for(int i = 0; i<child.GetLength(0);i++){
			for(int j = 0; j<child.GetLength(1);j++){
				for(int k = 0; k<child.GetLength(2);k++){
					if( (i+x) < parent.GetLength(0) && (j+y)< parent.GetLength(1) &&(k+z)<parent.GetLength(2)){
						//Debug.Log(parent.GetLength(0)+"  "+(i+x)+" - "+parent.GetLength(1)+"  "+(j+y)+" - "+parent.GetLength(2)+"  "+(k+z));
						parent[i+x,j+y,k+z] = child[i,j,k];
					}
				}
			}
		}
		return parent;
	}

    public static T[, ,] SwapValue3D<T>(T[, ,] a, T oldValue, T newValue)
    {
		for(int i = 0; i<a.GetLength(0);i++){
			for(int j = 0; j<a.GetLength(1);j++){
				for(int k = 0; k<a.GetLength(2);k++){
					if(a[i,j,k].Equals(oldValue)) a[i,j,k]=newValue;
				}
			}
		}
		return a;
	}

    public static T[, ,] Flood3D<T>(T[, ,] a, int x, int y, int z, T oldValue, T newValue)
    {
		if(x>-1 && x<a.GetLength(0) && y>-1 && y<a.GetLength(1) && z>-1 && z<a.GetLength(2)){
			if(a[x,y,z].Equals(oldValue)){
				a[x,y,z] = newValue;
				Flood3D(a,x-1,y,z,oldValue,newValue);
				Flood3D(a,x+1,y,z,oldValue,newValue);
				Flood3D(a,x,y-1,z,oldValue,newValue);
				Flood3D(a,x,y+1,z,oldValue,newValue);
				Flood3D(a,x,y,z-1,oldValue,newValue);
				Flood3D(a,x,y,z+1,oldValue,newValue);
			}
		}
		return a;
	}

    public static bool hasValue3D<T>(T[, ,] a, T value)
    {
		for (int i = 0; i < a.GetLength(0); i++) {
			for(int j = 0; j<a.GetLength(1);j++){
				for(int k = 0; k<a.GetLength(2);k++){
					if(a[i,j,k].Equals(value))return true;
				}
			}
		}
		return false;
	}

	public static T getRandom<T>(T[] a){
		return a [Mathf.FloorToInt (Random.value * a.Length)];
	}
	
}

