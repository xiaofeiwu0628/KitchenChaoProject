using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;
    private int IS_WALKING;
    [SerializeField]private PlayerController player;
    void Start()
    {
        anim = GetComponent<Animator>();
        IS_WALKING = Animator.StringToHash("IsWalking");
    }

    void Update()
    {
        anim.SetBool(IS_WALKING, player.GetIsWalking());   
    }
}
