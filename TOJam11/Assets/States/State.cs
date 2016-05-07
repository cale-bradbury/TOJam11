using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract void Awake();
    public abstract void Update();
    public abstract void OnDestroy();
}
