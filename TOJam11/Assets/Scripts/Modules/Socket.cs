using UnityEngine;
using System.Collections;

public class Socket : MonoBehaviour
{
    public Module.Types type = Module.Types.Chassis;

    [HideInInspector]
    public Module child;
    [HideInInspector]
    public Module parent;

    public void SetChild(Module m)
    {
        if (child != null)
        {
            DestroyImmediate(child.gameObject);
        }
        child = m;
        m.parent = this;
        m.transform.parent = transform;
        m.transform.localPosition = Vector3.zero;
        m.transform.localEulerAngles = Vector3.zero;
        m.transform.localScale = Vector3.one;
    }
}
