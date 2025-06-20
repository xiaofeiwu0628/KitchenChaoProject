using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    private int CUT;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        CUT = Animator.StringToHash("Cut");
    }

    public void PlayCut()
    {
        anim.SetTrigger(CUT);
    }
}
