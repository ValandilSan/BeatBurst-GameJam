using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatColor : MonoBehaviour
{

    public float _SpeedOfChange;
    private float test;
    private Material _Material;
    private bool _IsColorChange;
    // Start is called before the first frame update
    void Start()
    {
        _Material = GetComponent<MeshRenderer>().material;

       _Material.SetFloat("_IsBeat", 0);


    }
    public void ActiveColor()
    {
        _Material.SetFloat("_IsBeat", 1);
        _IsColorChange = true;
        test = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (_IsColorChange)
        {
            test = Mathf.Clamp(test -= Time.deltaTime * _SpeedOfChange, 0, 1);
            _Material.SetFloat("_IsBeat", test);

        }

    }
}
