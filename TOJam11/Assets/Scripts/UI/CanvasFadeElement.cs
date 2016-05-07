using UnityEngine;
using System.Collections;

public class CanvasFadeElement : MonoBehaviour {

    CanvasRenderer[] renderers;
    float alpha
    {
        get { return renderers[0].GetAlpha(); }
        set
        {
            FindRenderers();
            foreach (CanvasRenderer r in renderers)
                 r.SetAlpha(value);
        }
    }
    public float fadeOutTime = .5f;
    public float fadeOutDelay = .5f;
    public float fadeInTime = .3f;
    public float maxAlpha = 1;
    public bool startFaded = false;
    Coroutine coroutine;
    Callback endCallback;


	// Use this for initialization
	virtual protected void Start () {
        FindRenderers();
        if (startFaded)
            alpha = 0;
        else
            alpha = maxAlpha;
	}

    void FindRenderers()
    {
        renderers = GetComponentsInChildren<CanvasRenderer>();
    }

    // Update is called once per frame
    virtual public void Show(Callback callback = null)
    {
        FindRenderers();
        if(coroutine!=null)
            StopCoroutine(coroutine);
        CancelInvoke("StartHide");
        if (endCallback != null)
            endCallback();
        endCallback = callback;
        coroutine = StartCoroutine( Utils.AnimationCoroutine(AnimationCurve.EaseInOut(0, alpha, 1, maxAlpha), fadeInTime, SetAlpha,Finish));
    }
    virtual public void Hide(Callback callback = null)
    {
        FindRenderers();
        if (coroutine!=null)
            StopCoroutine(coroutine);
        CancelInvoke("StartHide");
        if (endCallback != null)
            endCallback();
        endCallback = callback;
        Invoke("StartHide", fadeOutDelay);        
    }

    void StartHide()
    {
        CancelInvoke("StartHide");
        coroutine = StartCoroutine(Utils.AnimationCoroutine(AnimationCurve.EaseInOut(0, alpha, 1, 0), fadeOutTime, SetAlpha, Finish));
    }

    public void SetAlpha(float a)
    {
        alpha = a;
    }

    void Finish()
    {
        if (endCallback == null)
            return;
        endCallback();
        endCallback = null;
    }
}
