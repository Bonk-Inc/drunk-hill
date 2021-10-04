using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float driveTime = 0.5f;
    [SerializeField]
    private float startDelay = 5f;
    

    private void Start() {
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget(){
        var startPos = transform.position;
        var targetPos = target.position;
        float way = 0;
        yield return new WaitForSecondsRealtime(startDelay - driveTime);
        while ( way < 1)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, way);
            way += Time.unscaledDeltaTime / driveTime;
            yield return null;
        }
    }
}
