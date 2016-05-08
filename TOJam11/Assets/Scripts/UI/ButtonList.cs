using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ButtonList : MonoBehaviour {
    public GameObject buttonPrefab;
    public RectTransform buttonParent;
    List<Button> buttons;
    public int Length
    {
        get { return buttons.Count; }
    }

    void Start()
    {
        buttons = new List<Button>();
	}
    
    public void Clear()
    {
        if (buttons == null)
            return;
        for (int i = buttons.Count - 1; i >= 0; i--)
        {
            Destroy(buttons[i].gameObject);
        }
        buttons = new List<Button>();
    }
    
    public delegate void ButtonCallback() ;
    public void Add(string s, ButtonCallback callback){
        GameObject g = Instantiate<GameObject>(buttonPrefab);
        g.transform.SetParent(buttonParent);
        Button b = g.GetComponent<Button>();
        b.GetComponentInChildren<Text>().text = s;
        b.onClick.AddListener(() => { callback(); });
        buttons.Add(b);
    }
}
