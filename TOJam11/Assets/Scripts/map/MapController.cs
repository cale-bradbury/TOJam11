using UnityEngine;
using System.Collections.Generic;

public class MapController : MonoBehaviour {
    public GameObject playerNodePrefab;
    [HideInInspector]
    public bool isPaused = false;
    [HideInInspector]
    public PlayerNode playerNode;
    [HideInInspector]
    public LocationNode[] nodes;
    


    void Start () {
        nodes = FindObjectsOfType(typeof(LocationNode)) as LocationNode[];
        foreach (LocationNode node in nodes) {
            node.map = this;
        }
        SpawnPlayerNode();        
    }

    void SpawnPlayerNode() {
        GameObject g = Instantiate<GameObject>(playerNodePrefab);
        g.transform.parent = transform;
        playerNode = g.GetComponent<PlayerNode>();
        playerNode.map = this;
        playerNode.SetLocation(GetStartLocationNode());        
        for (var i = 0; i < nodes.Length; i++)
        {
            nodes[i].playerNode = playerNode;
        }
    }

    LocationNode GetStartLocationNode() {
        for (var i = 0; i < nodes.Length; i++) {
            if (nodes[i].isStart) return nodes[i];
        }
        return null;
    }

    public void ActiveLocation(LocationNode node) {        
        node.Activate();
    }

    public void ResetLocations() {
        foreach (LocationNode n in nodes)
        {
            n.Reset();
        }
    }

    public void SetPause(bool val) {
        isPaused = val;
    }
}
