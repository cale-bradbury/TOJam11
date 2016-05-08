using UnityEngine;
using System.Collections;

public static class TransformExtensions
{
    public static void DestroyAllChildren( this Transform transform )
    {
        var children = new GameObject[ transform.childCount ];
        for( int i = 0; i < transform.childCount; i++ )
        {
            children[i] = transform.GetChild( i ).gameObject;
        }
        foreach( var child in children )
        {
            UnityEngine.Object.Destroy( child );
        }
    }
}
