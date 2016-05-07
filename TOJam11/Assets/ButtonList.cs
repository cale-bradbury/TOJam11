using UnityEngine;
using System.Collections.Generic;

public class ButtonList : MonoBehaviour {

    public GameObject buttonPrefab;
    public RectTransform buttonParent;
    public int count;
    List<GameObject> buttons;
    

	// Use this for initialization
	void Start () {
        buttons = new List<GameObject>();
        for (int i = 0; i < count; i++)
        {
            GameObject g = Instantiate<GameObject>(buttonPrefab);
            g.transform.SetParent( buttonParent);
            buttons.Add(g);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
