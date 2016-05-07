using UnityEngine;
using System;
using System.Collections.Generic;

public static class EventSystem
{
    static List<Action> _invokes = new List<Action>();

    public static void AddInvoke( Action invoke )
    {
        _invokes.Add( invoke );
    }

    public static void Invoke()
    {
        var length = _invokes.Count;
        for( int i = 0; i < length; i++ )
        {
            _invokes[i]();
        }
    }
}

public static class EventSystem<E>
{
    static List<E> _events = new List<E>();
    static List<Action<E>> _handlers = new List<Action<E>>();

    static EventSystem()
    {
        EventSystem.AddInvoke( Invoke );
    }

    public static void AddHandler( Action<E> handler )
    {
        _handlers.Add( handler );
    }

    public static void RemoveHandler( Action<E> handler )
    {
        _handlers.Remove( handler );
    }

    public static void AddEvent( E e )
    {
        _events.Add( e );
    }

    public static void Invoke()
    {
        var length = _events.Count;
        for( int i = 0; i < length; i++ )
        {
            foreach( var handler in _handlers )
            {
                handler( _events[i] );
            }
        }
        _events.RemoveRange( 0, length );
    }
}