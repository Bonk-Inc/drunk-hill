using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomAudio : MonoBehaviour
{
    [SerializeField] 
    private AudioSource audio;

    void Update()
    {
        int randomInt = Random.Range(0, 20_000);
        if (randomInt == 6 && !audio.isPlaying)
            audio.Play();
    }
}
