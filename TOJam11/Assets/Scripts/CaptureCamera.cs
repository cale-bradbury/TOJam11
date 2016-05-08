using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CaptureCamera : MonoBehaviour {

    public Camera camera;
    
    public RenderTexture CapturePrefab(GameObject g, int width, int height)
    {
        GameObject o = Instantiate<GameObject>(g);
        o.transform.parent = transform;
        o.transform.localPosition = new Vector3(0, 0, 5);
        RenderTexture t = new RenderTexture(width, height, 0);
        camera.targetTexture = t;
        camera.Render();
        camera.targetTexture = null;
        Destroy(o);
        return t;
    }
}
