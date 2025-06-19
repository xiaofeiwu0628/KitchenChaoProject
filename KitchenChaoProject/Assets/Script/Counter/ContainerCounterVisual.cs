using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    private Animator anim;

    int TR_OPENCLOSE;
    private void Start()
    {
        anim = GetComponent<Animator>();
        TR_OPENCLOSE = Animator.StringToHash("OpenClose");
    }

    public void PlayOpen()
    {
        anim.SetTrigger(TR_OPENCLOSE);
    }
}
