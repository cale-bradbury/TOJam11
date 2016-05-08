using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MapController : MonoBehaviour {
    public GameObject playerNodePrefab;
    public GameObject locationTooltip;
    private Text nameText; 
    private Text descriptionText;
    [HideInInspector]
    public bool isPaused = false;
    [HideInInspector]
    public PlayerNode playerNode;
    [HideInInspector]
    public LocationNode[] nodes;
    [HideInInspector]
    public Overworld overworld;



    void Start () {
        nodes = FindObjectsOfType(typeof(LocationNode)) as LocationNode[];
        foreach (LocationNode node in nodes) {
            node.map = this;
        }
        nameText = locationTooltip.transform.Find("Name").GetComponent<Text>();
        descriptionText = locationTooltip.transform.Find("Description").GetComponent<Text>();
        DisableTooltip();
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

    public void SetTooltip(string locationName, string description)
    {
        nameText.text = locationName;
        descriptionText.text = description;
    }

    public void EnableTooltip()
    {
        locationTooltip.SetActive(true);
    }

    public void DisableTooltip()
    {
        locationTooltip.SetActive(false);
    }

    /*
     * Requires a reference to the node the player is responsible for the encounter. If the encounter is random,
     * a bool must be passed in. This is because a node can potential trigger randon encounter AND/OR partially 
     * scripted ones.
     */
    public void StartEncounter(LocationNode node, bool isRandomEncounter)
    {
        //overworld.StartEncounter(node, isRandomEncounter);
    }
}
