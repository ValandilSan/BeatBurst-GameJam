using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTouch : MonoBehaviour
{
    [SerializeField] private FindTheRythm _Rythm;
    public delegate void BatEvent(string Size);
    public static event BatEvent PlayerisInTheRythm;
    public float _TimeToTouch;
    private bool _IsInRythm;
    private Coroutine _TimeCoroutine;
    private bool _IsAlreadyhit;



    [SerializeField] private AudioSource _AudioSource;
    [SerializeField] private List<AudioClip> _AudioClip;


    private void Start()
    {
        _IsAlreadyhit = false;
        _IsInRythm = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (_TimeCoroutine != null)
            {
                StopCoroutine(_TimeCoroutine);
                _TimeCoroutine = null;
            }

            if (_IsInRythm && _IsAlreadyhit == false)
            {

                _Rythm.StayInRythm();
                _IsAlreadyhit = true;

            }

           // DoSomeSounds();
            /* else
        {
            _Rythm.LoseRythm();
        }*/
           /* BReakObjetct Objet = other.GetComponent<BReakObjetct>();
            if (Objet != null)
            {
                Debug.Log(Objet.LifeOfTheObject);
                Debug.Log(Objet.GiveMysize());
                //  string Size = Objet.GiveMysize();
                //  PlayerisInTheRythm?.Invoke(Size);
                //Debug.Log(Size);
            }*/
        }
      


    }
    IEnumerator TimeToTouch()
    {
        yield return new WaitForSecondsRealtime(_TimeToTouch);
        _IsInRythm = false;
        _Rythm.LoseRythm();
    }

    public void IsInRythm(bool Rythm)
    {
        if (_TimeCoroutine == null && Rythm == true)
        {
            _TimeCoroutine = StartCoroutine(TimeToTouch());
        }
        _IsAlreadyhit = false;
        _IsInRythm = Rythm;
       // Debug.Log("Her");
    }
   private void DoSomeSounds()
    {
        _AudioSource.clip = _AudioClip[Random.Range(0, _AudioClip.Count)];
        _AudioSource.Play();
    }
}
