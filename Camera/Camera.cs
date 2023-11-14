using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[ExecuteInEditMode]
public class Camera : MonoBehaviour
{
    public GameObject _Player;
    public Vector3 _PositionOffset;
   // public Quaternion _RotationOffset;
    public Vector3 _CameraRotation;

    private Quaternion _Rotation;
    public float _SpeedOffset;

    private void Start()
    {
       SetupCamera();

     
    }
    private void SetupCamera()
    {
        transform.position = _Player.transform.position + _PositionOffset;
        transform.rotation = Quaternion.identity;
        transform.Rotate(_CameraRotation, Space.World);
        _Rotation = transform.rotation;
    }
    private void LateUpdate()
    {
        if( _Player != null ) 
        { 
            Vector3 targetPosition= _Player.transform.position + _PositionOffset;
            Quaternion targetRotation = _Rotation ;

            if(transform.position != targetPosition ) 
            {
            transform.position = Vector3.Lerp(transform.position, targetPosition, _SpeedOffset*Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation, _SpeedOffset*Time.deltaTime);
            
            
            }



        }
       
    }
}
