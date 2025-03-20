using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponsSystem;
using Health;

namespace Assembly_CSharp.Assets.Code.WeaponsSystem.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        
        [SerializeField] private Rigidbody _rigidbody;

        private float _currentDamage;
        
        public void Shoot(float force, Vector3 direction, float damage)
        
        {   _isReturning = false;
            _currentDamage = damage;
            _rigidbody.velocity = direction * force;
            StartCoroutine(WaitingLife());
        }

        private bool _isReturning = false;
        private IEnumerator WaitingLife()
        {
            yield return new WaitForSeconds(5);

            if (!_isReturning) 
            { 
                _isReturning = true; 
               ProjectilePool.Instance.Return(this); 
            }
             
        }
        public void OnTriggerEnter(Collider other)
        {
           
            if(_isReturning) return; 
            if(other.TryGetComponent<CharacterHealth>(out var characterHealth))
            {
                characterHealth.TakeDamage(_currentDamage);
            }
            _isReturning = true;
            ProjectilePool.Instance.Return(this);
        }   

    }

}