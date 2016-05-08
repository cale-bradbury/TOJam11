using UnityEngine;
using System.Collections;

public class DestroyAfterTurns : MonoBehaviour {

    public int turns;

    void BeginTurn()
    {
        turns--;
        if (turns <= 0)
        {
            Destroy(gameObject);
        }
    }
}
