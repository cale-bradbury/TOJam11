using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

    AnimationCurve currentCurve = AnimationCurve.Linear(0,0,0,0);
    float currentTime = 0;

    void Start()
    {

    }

    void Update()
    {
        currentTime += Time.deltaTime;
        var strength = currentCurve.Evaluate(currentTime);
        transform.localPosition = new Vector3(Random.value * strength, Random.value * strength, Random.value * strength) - (strength * .5f*Vector3.one);
    }

    public void Shake(float strength = .3f, float time = .4f){
        currentTime = 0;
        currentCurve = AnimationCurve.EaseInOut(0, strength, time, 0);
    }

}
