using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkAbberation : MonoBehaviour
{

    [SerializeField]
    private float acceleration = 5;

    [SerializeField]
    private float abberationEqualsApprox = 0.1f;

    [SerializeField]
    private float minDrunkAbberation, maxDrunkAbberation;

    private const string DRUNKNESS_SETTING_KEY = "Camera Drunkness";

    private float currentAbberation = 0, targetAbberation = 0;

    private void HandleMove(){
        if(ApproximatelyEqual(currentAbberation, targetAbberation)){
            CreateNewTarget();
        }
        LerpToTarget();
    }

    private bool ApproximatelyEqual(float a, float b){
        return Mathf.Abs(currentAbberation - targetAbberation) < abberationEqualsApprox;
    }

    private void CreateNewTarget(){
        targetAbberation = Random.Range(minDrunkAbberation, maxDrunkAbberation);
    }

    private void LerpToTarget(){
        currentAbberation = Mathf.Lerp(currentAbberation, targetAbberation, acceleration * Time.deltaTime);
    }
}
