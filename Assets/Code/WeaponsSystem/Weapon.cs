
using Assembly_CSharp.Assets.Code.WeaponsSystem.Projectiles;
using UnityEngine;

namespace WeaponsSystem
{


    public class Weapon : MonoBehaviour
    {
      
      [SerializeField] private Transform _spawnPosition; 
      [SerializeField] private float _force = 10;
      [SerializeField] private float _damage = 1;

       void Update()
        {
           if(!Input.GetMouseButtonDown(0)) return;
           Shoot();
        }
          
  
       private void Shoot()
       {
            var projectile = ProjectilePool.Instance.Get();
            if (projectile == null) 
            {
               Debug.LogWarning("el pool no devolvio un proyectil valido");
               return; 
            }
            projectile.transform.position = _spawnPosition.position;
            projectile.gameObject.SetActive(true);
            projectile.Shoot(_force, transform.forward, _damage);

       }
    }
}
