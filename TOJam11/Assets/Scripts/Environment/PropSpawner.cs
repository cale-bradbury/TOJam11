using UnityEngine;
using System.Collections;

public class PropSpawner : MonoBehaviour {
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

        Vector3 tempPos = transform.position;        
        tempPos.z = 20f;    // TODO: this is just random right now. This value should be be related to screen size or something.
        if (small)
        {
            xPos = Random.Range(smallPropSpawn[0], smallPropSpawn[1]);
            tempPos.x = Random.value > 0.5 ? xPos : -xPos;
            Debug.Log(xPos);
            Debug.Log(tempPos);
            prop = Instantiate(ArrayUtils.getRandom<GameObject>(smallPropPrefabs), tempPos, Quaternion.identity) as GameObject;          
        } else {
            xPos = Random.Range(largePropSpawn[0], largePropSpawn[1]);
            tempPos.x = Random.value > 0.5 ? xPos : -xPos;
            prop = Instantiate(ArrayUtils.getRandom<GameObject>(largePropPrefabs), tempPos, Quaternion.identity) as GameObject;
        }
        
        //prop.transform.position = tempPos;
        prop.GetComponent<PropScroller>().scrollSpeed = scrollSpeed * 11.13f;
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
