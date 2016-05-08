using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PrefabDisplay : MonoBehaviour {

    public GameObject prefab;
    public string name;
    public RawImage img;
    public Text text;

	// Use this for initialization
	void Start () {
        img.texture = FindObjectOfType<CaptureCamera>().CapturePrefab(prefab,128,128);
        text.text = name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
