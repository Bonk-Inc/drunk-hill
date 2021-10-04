using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LorryObstacle : MonoBehaviour
{
    [SerializeField]
    private float rollSpeed;

    private void Update() {
        var localPos = transform.localPosition;
        localPos.y += rollSpeed * Time.deltaTime;
        transform.localPosition = localPos;
    }
}
