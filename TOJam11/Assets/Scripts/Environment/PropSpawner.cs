﻿using UnityEngine;
using System.Collections.Generic;

public class PropSpawner : MonoBehaviour
{
    public GameObject[] smallPropPrefabs;
    public GameObject[] largePropPrefabs;
    public float spawnRate = 50f;               // how often this will attempt to spawn props
    public float minSpawnChance = 0.05f;
    public float maxSpawnChance = 0.5f;
    public float spawnChanceIncrement = 0.001f;
    public float spawnSmallPropChance = 0.85f;  // chance of prop being small vs large.
    private float currentSpawnChance;
    public float scrollSpeed = 0.75f;
    [HideInInspector]
    public float[] smallPropSpawn;
    [HideInInspector]
    public float[] largePropSpawn;
    private float lastSpawnAttempt = 0f;
    private List<Renderer> props = new List<Renderer>();

    void Start()
    {
        currentSpawnChance = minSpawnChance;
    }

    void Update()
    {
        AttemptSpawnProp();
        UpdateProps();
    }

    void AttemptSpawnProp()
    {
        if (lastSpawnAttempt + spawnRate < Time.time && ShouldSpawnProp())
        {
            lastSpawnAttempt = Time.time;
            SpawnProp();
        }
    }

    void UpdateProps()
    {
        for (var i = 0; i < props.Count; i++)
        {
            Renderer prop = props[i];
            Vector3 tempPos = prop.transform.localPosition;
            float z = Time.deltaTime * scrollSpeed * 10f;
            tempPos.z -= z;
            prop.transform.localPosition = tempPos;

            if (props[i].transform.localPosition.z < 0 && !props[i].isVisible)
            {
                props.RemoveAt(i);
                Destroy(prop.gameObject);
                i--;
            }
        }
    }

    void SpawnProp()
    {
        float xPos;
        bool small = Random.value < spawnSmallPropChance;
        GameObject prop;
        Vector3 tempPos = new Vector3(0f, 0f, 20f);
        if (small)
        {
            xPos = Random.Range(smallPropSpawn[0], smallPropSpawn[1]);
            tempPos.x = Random.value > 0.5 ? xPos : -xPos;
            prop = Instantiate<GameObject>(ArrayUtils.getRandom<GameObject>(smallPropPrefabs));
        }
        else {
            xPos = Random.Range(largePropSpawn[0], largePropSpawn[1]);
            tempPos.x = Random.value > 0.5 ? xPos : -xPos;
            prop = Instantiate<GameObject>(ArrayUtils.getRandom<GameObject>(largePropPrefabs));
        }
        prop.transform.parent = transform;
        prop.transform.localPosition = tempPos;
        props.Add(prop.GetComponent<Renderer>());
    }

    bool ShouldSpawnProp()
    {
        float chance = Random.value;
        bool spawn = chance < currentSpawnChance;
        currentSpawnChance += spawnChanceIncrement;
        if (spawn)
        {
            ResetSpawnChance();
        }
        else
        {
            IncreaseSpawnChance();
        }
        return spawn;
    }

    void ResetSpawnChance()
    {
        currentSpawnChance = minSpawnChance;
    }

    void IncreaseSpawnChance()
    {
        currentSpawnChance = currentSpawnChance < maxSpawnChance ? currentSpawnChance + spawnChanceIncrement : maxSpawnChance;
    }
}
