using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Health 
{
    public class CharacterHealth : MonoBehaviour
   {
     [SerializeField] private float _maxHealth = 10;
     private float _currentHealth;

        private void Start()
        {
            _currentHealth = _maxHealth;
        
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
               Death();
            }

        }
        private void Death()
        {
            gameObject.SetActive(false);
        }

    }
}