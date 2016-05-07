﻿using UnityEngine;
using System.Collections;

public class EnvironmentScroller : MonoBehaviour {

    public GameObject props;
    private PropScroller propScroller;
    public GameObject background;
    private BackgroundScroller bgScroller;

    public float scrollSpeed = 0.75f;
    public float gridWidth = 0f;
    private float[] smallPropSpawn;
    private float[] largePropSpawn;

    void Start()
    {


        bgScroller = background.GetComponent<BackgroundScroller>();
        bgScroller.scrollSpeed = scrollSpeed;
        propScroller = props.GetComponent<PropScroller>();
        propScroller.scrollSpeed = scrollSpeed;
        propScroller.smallPropSpawn = new float[2] { 0f, gridWidth / 2 };
        propScroller.largePropSpawn = new float[2] { gridWidth / 4, gridWidth / 2};
    }
}