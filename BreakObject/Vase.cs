using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Vase : BReakObjetct
{
    public GameObject _PrefabFloat;
    private GameObject _prefabText;
    private TextMeshPro _prefabTextUGUI;

    [SerializeField] private ParticleSystem _Particules;
    public float YPosText;
    public override void Start()
    {
        base.Start();
    }

    public override void ExplodeObject()
    {
        //_ExplosionPosition = PositionContact;
        MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.enabled = false;
        }
        _Particules.Play();
        Destroy(_Particules, 1f);
       // DoSomeSounds();
        base.ExplodeObject();
    }

   



    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Bat"))
        {
            if (_LifeOfTheObject <= 0)
            {
                GiveMysize(_Size);
                Vector3 NewPos = new Vector3(transform.position.x, transform.position.y + YPosText, transform.position.z);

                _prefabText = Instantiate(_PrefabFloat, NewPos, Quaternion.identity);
                _prefabTextUGUI = _prefabText.GetComponentInChildren<TextMeshPro>();
                _prefabTextUGUI.text = _HUDScript.WhatToShow(_Size).ToString();
                Destroy(_prefabText, 1.0f);

                ObjectExplode(other);
            }
            else { _LifeOfTheObject--; }
        }


    }

    public override void DoSomeSounds()
    {
        _AudioSource.clip = _AudioClip[Random.Range(0, _AudioClip.Count)];
        _AudioSource.Play();
    }
}
