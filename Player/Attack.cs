using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public AnimationClip _PlayerHitAnimation;
    public float _TimeBeforerestartTheHit;
    [SerializeField] private GameObject _Weapon;
    [SerializeField] FindTheRythm _Rythm;

    private Collider _WeaponCollider;

    public bool _IsAttacking;
    //Animator
    private bool _CanHeHit = true;
    private Animator _PlayerAnimator;
    private Coroutine _Playerhit;

    private void Start()
    {
        _PlayerAnimator = GetComponentInChildren<Animator>();
        _WeaponCollider = _Weapon.GetComponent<Collider>();
        _WeaponCollider.enabled = false;
    }

    IEnumerator TimeBeforeReAttack()
    {
        _IsAttacking = true;
        yield return new WaitForSecondsRealtime(_PlayerHitAnimation.length * _TimeBeforerestartTheHit);
        _IsAttacking = false;
        _CanHeHit = true;
        _Playerhit = null;
    }

    #region Collider
    public void ActiveCollider()
    {
        if (_WeaponCollider != null && _WeaponCollider.enabled == false)
        {
            _WeaponCollider.enabled = true;
        }

    }
    public void DisableCollider()
    {
        if (_WeaponCollider != null && _WeaponCollider.enabled == true)
        {
            _WeaponCollider.enabled = false;
        }
    }
    #endregion


   
    private void Update()
    {

        if (_PlayerAnimator != null && _CanHeHit)
        {

            if (Input.GetButton("Fire1") && Time.timeScale == 1)
            {
                _PlayerAnimator.SetTrigger("Hit");
                _CanHeHit = false;
                _Rythm.CheckTheRythm();
                if (_Playerhit == null)
                {
                    _Playerhit = StartCoroutine(TimeBeforeReAttack());
                }

            }

        }
    }
}
