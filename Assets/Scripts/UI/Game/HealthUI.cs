using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    
    [SerializeField]
    private Health health;

    [SerializeField]
    private List<Image> heartFill;

    private void Start() {
        UpdateHearts();
        health.OnHealthChange += (args) => UpdateHearts();
    }

    private void UpdateHearts(){
        for (var i = 0; i < heartFill.Count; i++)
        {  
           heartFill[i].enabled =  health.CurrentHealth > i;
        }
    }

}
