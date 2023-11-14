using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fridge : BReakObjetct
{
    public GameObject _PrefabFloat;
    private GameObject _prefabText;
    private TextMeshPro _prefabTextUGUI;
    public List<GameObject> _Decals;

    public float YPosText;
    [SerializeField] private ParticleSystem _Particules;
    public override void Start()
    {
        foreach (GameObject obj in _Decals) { obj.SetActive(false); }
        base.Start();
    }

    public override void ExplodeObject()
    {
        _Particules.Play();
        Destroy(_Particules, 1f);
        foreach (GameObject obj in _Decals) { obj.SetActive(false); }
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
            else
            {
                _Particules.Play();
                _LifeOfTheObject--;
                for (int i = 0; i < _Decals.Count; i++)
                {
                    if (_Decals[i].activeSelf == false)
                    {
                        _Decals[i].SetActive(true);
                        i = _Decals.Count;
                        return;
                    }
                }


            }
        }


    }
}
