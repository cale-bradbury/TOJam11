using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ButtonList : CanvasFadeElement {
    RectTransform rt;
    public GameObject buttonPrefab;
    public RectTransform buttonParent;
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
    public int Length
    {
        get { return buttons.Count; }
    }

    public Color defaultColor = Color.white;
    public Color selectedColor = Color.red;
    ScrollRect scroll;
    float scrollTarget = 0;
    public float scrollSmoothing = .1f;

    override protected void Start()
    {
        base.Start();
        rt = GetComponent<RectTransform>();
        scroll = GetComponent<ScrollRect>();
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

    public override void Hide(Callback callback = null)
    {
        base.Hide(callback);

        for (int i = buttons.Count - 1; i >= 0; i--)
        {
            buttons[i].onClick = null;
        }
    }

    public void MoveToMouse()
    {
        Show();
        Vector2 v = rt.pivot;
        if (Input.mousePosition.x > Screen.width * .5f)
            v.x = 1;
        else
            v.x = 0;
        if (Input.mousePosition.y < Screen.height * .5f){
            foreach (Button b in buttons)
                b.transform.SetAsFirstSibling();
            v.y = 0;
        }
        else
            v.y = 1;
        rt.pivot = v;
        transform.position = Input.mousePosition;
    }

    public delegate void ButtonCallback() ;
    public void Add(string s, ButtonCallback callback){
        GameObject g = Instantiate<GameObject>(buttonPrefab);
        g.transform.SetParent(buttonParent);
        Button b = g.GetComponent<Button>();
        b.GetComponentInChildren<Text>().text = s;
        b.onClick.AddListener(() => { callback(); });
        buttons.Add(b);
        Vector2 r = rt.sizeDelta;
        r.y = buttonParent.sizeDelta.y;
        rt.sizeDelta = r;
    }

    void Update()
    {
        Vector2 r = rt.sizeDelta;
        r.y = buttonParent.sizeDelta.y;
        rt.sizeDelta = r;
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
	
    void OnSelect()
    {
        if (selected < 0)
            return;
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
