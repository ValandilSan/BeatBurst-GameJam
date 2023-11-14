using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BReakObjetct : MonoBehaviour
{

    [SerializeField] protected List<GameObject> bodies = new List<GameObject>();
    [SerializeField] protected GameObject Explosion;
    [SerializeField] private float _RadiusExplosion;
    [SerializeField] protected float _ExplosionForce;
    [SerializeField] protected float _LifeOfTheObject;
    [SerializeField] protected string _Size;


    [SerializeField] protected AudioSource _AudioSource;
    [SerializeField] protected List<AudioClip> _AudioClip;

    public delegate void OnScoring(string Size);
    public static event OnScoring GiveTheSizeForScoring;

  

    public virtual string Size => _Size;
    public virtual float Explosionradius => _RadiusExplosion;
    public virtual List<GameObject> Bodies => bodies;
    public virtual float LifeOfTheObject=> _LifeOfTheObject;

    private protected HUD _HUDScript;
    private List<Rigidbody> _LittlesRigibody = new List<Rigidbody>();
    private List<Collider> _LittlePieces = new List<Collider>();

    private Rigidbody body;
    private Collider _BoxCollider;
    private NavMeshObstacle _NavMeshObstacle;
   protected private Vector3 _ExplosionPosition;

   
    private void Awake()
    {
      
        /*  _BoxCollider = GetComponent<Collider>();

          _NavMeshObstacle = GetComponent<NavMeshObstacle>();
          body = GetComponent<Rigidbody>();
          foreach (var b in bodies)
          {
              _LittlePieces.Add(b.GetComponent<Collider>());
              _LittlesRigibody.Add(b.GetComponent<Rigidbody>());

              //b.Sleep();
          }*/
      
        _BoxCollider = GetComponent<Collider>();

        _NavMeshObstacle = GetComponent<NavMeshObstacle>();
        body = GetComponent<Rigidbody>();
        foreach (var b in bodies)
        {
            _LittlePieces.Add(b.GetComponent<Collider>());
            _LittlesRigibody.Add(b.GetComponent<Rigidbody>());

            //b.Sleep();
        }
       
    }
   

    public virtual void Start()
    {

        InitializeItemToDestroy Initi = GetComponentInParent<InitializeItemToDestroy>();
        _HUDScript = Initi._HudScript;
        foreach (var b in _LittlesRigibody)
        {
            b.Sleep();
        }
        foreach (var item in _LittlePieces)
        {
            item.enabled = false;
        }
    }
 
    public virtual void ObjectExplode(Collider other)
    {
        Collider collider = other.GetComponent<Collider>();
        collider.enabled = false;
        _ExplosionPosition = _BoxCollider.ClosestPoint(other.transform.position);

        Explosion.transform.position = _ExplosionPosition;
        MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.enabled = false;
        }
        if (_NavMeshObstacle != null)
        {
            _NavMeshObstacle.enabled = false;
        }

        ExplodeObject();
      //  Debug.Log(other.ClosestPoint(other.transform.position));
        //Debug.Log("Trigger");
    }

    public virtual void GiveMysize(string Size)
    {

        GiveTheSizeForScoring?.Invoke(Size);   
    }
  
    
    public  virtual void ExplodeObject()
    {
        _BoxCollider.enabled = false;
        foreach (var item in bodies)
        {
            item.SetActive(true);
        }
        foreach (var item in _LittlePieces)
        {
            item.enabled = true;

        }

        foreach (var lol in _LittlesRigibody)
        {

            lol.AddExplosionForce(_ExplosionForce, Explosion.transform.position, _RadiusExplosion);
            lol.WakeUp();

        }
    }


    public virtual void DoSomeSounds()
    {
        
    }
    private void Update()
    {
        
    }
}
