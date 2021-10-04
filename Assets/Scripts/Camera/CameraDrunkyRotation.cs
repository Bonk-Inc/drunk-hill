using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrunkyRotation : MonoBehaviour
{
    
    [SerializeField]
    public float maxRotation;

    [SerializeField]
    public float moveSpeed;

    [SerializeField]
    private float approxPosition = 0.1f;

    private float target;
    private float current;
    private Vector3 velocity = Vector3.zero;

    private float multiplier = 1f;

    private void Awake() {
        CreateNewTarget();
    }


    private void Update() {
        multiplier = PlayerPrefs.GetFloat(CameraDrunknessSetting.DRUNKNESS_SETTING_KEY, 1);
        current = Mathf.Lerp(current, target, moveSpeed*Time.deltaTime);
        transform.localRotation = Quaternion.Euler(0, 0, current);
        

        if(Mathf.Abs(current - target) < approxPosition){
            CreateNewTarget();
        }
    }

    private void CreateNewTarget(){
        target = Random.Range(-maxRotation, maxRotation) * multiplier;
    }


}
