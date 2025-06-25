using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private PlayerController player;
    private float stepSoundRate = 0.1f;
    private float stepSoundTimer = 0;
    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (player.GetIsWalking())
        {
            stepSoundTimer += Time.deltaTime;
            if (stepSoundTimer >= stepSoundRate)
            {
                stepSoundTimer = 0;
                SoundManager.Instance.PlayStepSound();
            }
        }
    }
}
