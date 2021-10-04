using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrunkyMovement : MonoBehaviour
{
    [SerializeField]
    public float maxMovement;

    [SerializeField]
    public float moveSpeed;

    [SerializeField]
    private float approxPosition = 0.1f;

    private Vector2 target;
    private Vector3 velocity = Vector3.zero;

    private float multiplier = 1f;

    private void Awake() {
        CreateNewTarget();
    }


    private void Update() {
        multiplier = PlayerPrefs.GetFloat(CameraDrunknessSetting.DRUNKNESS_SETTING_KEY, 1);
        transform.localPosition =  Vector3.SmoothDamp(transform.localPosition, (Vector3)target, ref velocity, moveSpeed);
        // transform.localPosition = Vector2.Lerp(transform.localPosition, target, moveSpeed * Time.deltaTime);
        
        if(((Vector2)transform.localPosition - target).magnitude < approxPosition){
            CreateNewTarget();
        }
    }

    private void CreateNewTarget(){
        target = new Vector2(
            Random.Range(-maxMovement, maxMovement) * multiplier,
            Random.Range(-maxMovement, maxMovement) * multiplier
        );
    }

}
