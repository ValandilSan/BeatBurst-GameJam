using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    private Attack _PlayerAttack;

    private void Awake()
    {
        _PlayerAttack = GetComponentInParent<Attack>();
    }

    public void ActiveCollider()
    {
       _PlayerAttack.ActiveCollider();
        //Debug.Log("Active");
    }

    public void DisableCollider()
    {
       _PlayerAttack.DisableCollider();
        //Debug.Log("Disable");
    }

}
