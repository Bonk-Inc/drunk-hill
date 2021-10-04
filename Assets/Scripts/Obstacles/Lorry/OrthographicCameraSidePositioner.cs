using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthographicCameraSidePositioner : MonoBehaviour
{
    
    [SerializeField]
    private float offset = 0;

    private void Awake() {
        Camera camera = Camera.main;
        float y = camera.transform.position.y - camera.orthographicSize;
        
        Vector3 pos = transform.position;
        pos.y = y;
        transform.position = pos;
    }

}
