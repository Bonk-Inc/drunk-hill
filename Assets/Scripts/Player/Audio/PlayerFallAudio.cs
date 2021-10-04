using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallAudio : MonoBehaviour
{

    [SerializeField]
    private PlayerHitHandler playerHitHandler;

    [SerializeField]
    private AudioSource fallAudioSource;
    [SerializeField]
    private AudioSource voiceAudioSource;

    [SerializeField]
    private AudioClip[] hurtNoises;

    private void Awake() {
        playerHitHandler.OnPlayerHitObstacle += PlayFallAudio;
    }

    private void PlayFallAudio(bool isDead) {
        if(voiceAudioSource.isPlaying)
            return;

        var clipNumber = Random.Range(0, hurtNoises.Length);
        
        AudioClip clip = hurtNoises[clipNumber];
        voiceAudioSource.clip = clip;

        voiceAudioSource.Play();    
        fallAudioSource.Play();
    }
}
