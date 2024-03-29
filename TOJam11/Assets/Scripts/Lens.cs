﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Lens<T>
{
    public int priority;
    public Func<T, T> transformation;
    public Lens(int priority, Func<T, T> transformation)
    {
        this.priority = priority;
        this.transformation = transformation;
    }
}

public class LensedValue<T>
{
    public T initialValue;
    List<Lens<T>> lenses;

    public LensedValue(T initialValue)
    {
        this.initialValue = initialValue;
        this.lenses = new List<Lens<T>>();
    }

    public LensToken AddLens(Lens<T> lens)
    {
        lenses.Add(lens);
        return new LensToken(
            () => lenses.Remove(lens)
        );
    }

    public T GetValue()
    {
        T tmp = (T)(initialValue.GetType() == typeof(ICloneable) ? ((ICloneable)initialValue).Clone() : initialValue);
        lenses.Sort((x, y) => x.priority - y.priority);
        foreach (var lens in lenses)
        {
            tmp = lens.transformation(tmp);
        }
        return tmp;
    }
}

public class LensToken
{

    Action action;

    public LensToken(Action action)
    {
        this.action = action;
    }

    public void Remove()
    {
        action();
    }
}