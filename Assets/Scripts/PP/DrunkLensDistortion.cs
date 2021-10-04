using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DrunkLensDistortion : MonoBehaviour
{
    [SerializeField]
    private PostProcessVolume volume;

    private LensDistortion lensDistortion;

    [SerializeField]
    private float acceleration = 5;

    [SerializeField]
    private float abberationEqualsApprox = 0.1f;

    [SerializeField]
    private float minDrunkAbberation = 0, maxDrunkAbberation = 1;

    private const string DRUNKNESS_SETTING_KEY = "Camera Drunkness";

    private float currentAbberation = 0, targetAbberation = 0;

    private void Awake() {
        lensDistortion = volume.sharedProfile.GetSetting<LensDistortion>();
    }

    private void Update() {
        HandleMove();
        
    }

    private void HandleMove(){
        if(ApproximatelyEqual(currentAbberation, targetAbberation)){
            CreateNewTarget();
        }
        LerpToTarget();
        MoveInCurrentDirection();
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

    private void MoveInCurrentDirection(){
        lensDistortion.intensity.Override(currentAbberation * PlayerPrefs.GetFloat(DRUNKNESS_SETTING_KEY, 1));
    }
}
