using UnityEngine;
using System.Collections.Generic;

public class MapController : MonoBehaviour {
    public GameObject playerNodePrefab;
    [HideInInspector]
    public PlayerNode playerNode;
    public LocationNode[] nodes;

	void Start () {
        nodes = FindObjectsOfType(typeof(LocationNode)) as LocationNode[];
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
        foreach(LocationNode n in nodes)
        {
            n.Reset();
        }
        node.Activate();
    }
}
