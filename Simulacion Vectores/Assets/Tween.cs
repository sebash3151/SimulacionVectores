using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Easing
{
    Linear,
    EaseInQuad,
    Ease
}

public class Tween : MonoBehaviour
{
    [SerializeField] AnimationCurve customCurve;

    [Range(0, 1)] [SerializeField] float t = 0f;
    [SerializeField] float duration = 1f, acumulateTime = 0f;
    [SerializeField] Transform target;
    [SerializeField] bool isPlaying = false;

    Vector3 startpos;
    Vector3 endPos;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startTween();
        }

        if (!isPlaying)
        {
            return;
        }

        if (t >= 1)
        {
            Debug.Log("Terminado!!!");
            isPlaying = false;
            return;
        }

        float finalT = 0;

        finalT = customCurve.Evaluate(t);

        t = acumulateTime / duration;
        transform.position = Vector2.Lerp(startpos, endPos, finalT);
        acumulateTime += Time.deltaTime;
    }

    private void startTween()
    {
        startpos = transform.position;
        endPos = target.position;
        t = 0;
        acumulateTime = 0f;
        isPlaying = true;
    }
}
