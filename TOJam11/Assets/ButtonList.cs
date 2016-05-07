using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonList : MonoBehaviour {

    public GameObject buttonPrefab;
    public RectTransform buttonParent;
    public int count;
    List<Button> buttons;
    Button current;
    int _selected = 0;
    int selected
    {
        get { return _selected; }
        set
        {
            value = Mathf.Max(value, 0);
            value = Mathf.Min(value, buttons.Count - 1);
            _selected = value;
            OnSelect();
        }
    }

    public Color defaultColor = Color.white;
    public Color selectedColor = Color.red;
    ScrollRect scroll;
    float scrollTarget = 0;
    public float scrollSmoothing = .1f;

	// Use this for initialization
	void Start () {
        scroll = GetComponent<ScrollRect>();
        buttons = new List<Button>();
        for (int i = 0; i < count; i++)
        {
            GameObject g = Instantiate<GameObject>(buttonPrefab);
            g.transform.SetParent( buttonParent);
            Button b = g.GetComponent<Button>();
            b.onClick.AddListener(() => { OnClick(b); });
            buttons.Add(b);
        }
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            selected++;
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            selected--;

        if (Input.mouseScrollDelta.y < 0)
            selected++; 
        else if (Input.mouseScrollDelta.y > 0)
            selected--;

        scroll.verticalNormalizedPosition = Mathf.Lerp(scroll.verticalNormalizedPosition, scrollTarget, scrollSmoothing);
    }
	
	// Update is called once per frame
	void OnClick (Button b) {
        selected = buttons.IndexOf(b);
	}

    void OnSelect()
    {
        Debug.Log(selected);
        ColorBlock block;
        if (current!=null)
        {
            block = current.colors;
            block.normalColor = block.highlightedColor = defaultColor;
            current.colors = block;
        }
        current = buttons[selected];
        block = current.colors;
        block.normalColor = block.highlightedColor = selectedColor;
        current.colors = block;
        scrollTarget = 1 - (float)current.transform.GetSiblingIndex() / ((float)scroll.content.transform.childCount-1);
    }
}
