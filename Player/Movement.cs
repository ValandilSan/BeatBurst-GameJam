using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : PlayerObserver
{

    [SerializeField] private float _SpeedCharacter;
 
    [SerializeField] private float _SpeedRotation;

    private Animator _PlayerAnimator;

    #region Movement
    private void Start()
    {
        _PlayerAnimator = GetComponentInChildren<Animator>();
    }
    private void Movemement()
    {

        if (gameObject != null && Time.timeScale !=0)
        {
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
           
            
              /*  transform.Translate((transform.forward * _Speed * Time.deltaTime), Space.World);
                if (direction.magnitude > 0.10f)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), _AirControlIntensity * Time.deltaTime);
                }*/ 
            
           /* if (!_IsAttack)
            {
                if ((Input.GetAxis("LS_H") != 0 || (Input.GetAxis("LS_V") != 0)))
                {
                    SwitchState(EPlayerState.Movement);
                }

            }*/
            transform.Translate(direction * (_SpeedCharacter * Time.deltaTime), Space.World);

            
            //Rotation
            if (direction.magnitude > 0.10f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), _SpeedRotation * Time.deltaTime);
            }

            _PlayerAnimator.SetFloat("Movement", direction.magnitude);

        }


    }

    #endregion

    

    private void LateUpdate()
    {
        Movemement();

    }
  



}
