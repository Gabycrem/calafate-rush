using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Code.WeaponsSystem.Projectiles;
using UnityEngine;

namespace WeaponsSystem
{

 public class ProjectilePool : MonoBehaviour
 {
    [SerializeField] private Projectile _projectile; 

    [Header("Settings")]
    [SerializeField] private int _maxCapacity;
    [SerializeField] private int _initCapacity;

    private Queue<Projectile> _queue = new(); 
       public static ProjectilePool Instance;

    void Awake()
    {
        
         if(ProjectilePool.Instance != null)
         {
            
            Destroy(this);
             
            return;
         }  
         Instance = this;
    }
    void Start()
    {   
        for (int i = 0; i < _initCapacity; i++)
        {
            var projectile = Instantiate(_projectile, transform);
            projectile.gameObject.SetActive(false);
            _queue.Enqueue(projectile); 
        }
    }
   
    public Projectile Get() 
    {
      if (_queue.Count > 0)
       {
        var projectileInstance = _queue.Dequeue();
        projectileInstance.transform.parent = null;
        return projectileInstance;
        

        }
        var projectile = Instantiate(_projectile);
        projectile.gameObject.SetActive(false);
        return projectile;
       
    }

    public void Return(Projectile projectile)
    {   
        if(_queue.Count >= _maxCapacity) 
        {
            projectile.gameObject.SetActive(false);
            return;
        }
        projectile.gameObject.SetActive(false);
        projectile.transform.parent = transform; 
        _queue.Enqueue(projectile); 
    }
  }
}