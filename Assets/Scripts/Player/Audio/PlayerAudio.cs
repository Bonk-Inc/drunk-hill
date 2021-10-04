using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{

    [SerializeField]
    private PlayerHitHandler playerHitHandler;

    [SerializeField]
    private AudioSource fallAudioSource, voiceAudioSource, footstepsAudioSource;

    [SerializeField]
    private AudioClip[] hurtNoises, stepNoises;

    private void Awake() {
        playerHitHandler.OnPlayerHitObstacle += PlayFallAudio;
    }

    private void PlayFallAudio(bool isDead) {
        if(voiceAudioSource.isPlaying)
            return;

        voiceAudioSource.clip = chooseRandomClip(hurtNoises);

        voiceAudioSource.Play();    
        fallAudioSource.Play();
    }

    public void Step(){

        footstepsAudioSource.clip = chooseRandomClip(stepNoises);

        footstepsAudioSource.Play();
    }

    private AudioClip chooseRandomClip(AudioClip[] clips) {
        var clipNumber = Random.Range(0, clips.Length);
        
        return clips[clipNumber];
    }
}
