using UnityEngine;
using System.Collections;

public class PropScroller : MonoBehaviour {
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

    void Start()
    {
        currentSpawnChance = minSpawnChance;
    }

    void Update() {
        if ( lastSpawnAttempt + spawnRate < Time.time && ShouldSpawnProp())
        {
            lastSpawnAttempt = Time.time;
            SpawnProp();
        }
    }

    void SpawnProp()
    {
        float xPos;
        bool small = Random.value < spawnSmallPropChance;
        GameObject prop;
        if (small)
        {
            xPos = Random.Range(smallPropSpawn[0], smallPropSpawn[1]);
            prop = Instantiate<GameObject>(ArrayUtils.getRandom<GameObject>(smallPropPrefabs));          
        } else {
            xPos = Random.Range(largePropSpawn[0], largePropSpawn[1]);
            prop = Instantiate<GameObject>(ArrayUtils.getRandom<GameObject>(largePropPrefabs));
        }
        Vector3 tempPos = prop.transform.position;
        tempPos.x = xPos;
        prop.transform.position = tempPos;
        // set the y pos
        // add a prop script that moves the new prop
    }

    bool ShouldSpawnProp() {
        float chance = Random.value;
        bool spawn = chance < currentSpawnChance;
        currentSpawnChance += spawnChanceIncrement;
        if (spawn)
        {
            ResetSpawnChance();
        } else
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
