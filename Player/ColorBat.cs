using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBat : MonoBehaviour
{
    private Material _BatMaterial;
    [SerializeField] private float _Speed;

    [SerializeField] private FindTheRythm _Marge;
    private float _CurrentValue;
    private void Start()
    {
        _BatMaterial = GetComponent<SkinnedMeshRenderer>().material;
        _CurrentValue = 0;
    }

    public void ChangeTheColor()
    {
        _BatMaterial.SetFloat("_OnBeat",1);
        _CurrentValue = _BatMaterial.GetFloat("_OnBeat");
    }

    private void Update()
    {
        if (_CurrentValue >0)
        {
            _CurrentValue = Mathf.Clamp(_CurrentValue -= Time.deltaTime * _Speed,0,1);
            _BatMaterial.SetFloat("_OnBeat", _CurrentValue);
           
        }
    }
}
