using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Debug.Log("Player is dead!");
            // Lógica para manejar la muerte del jugador
            Death();
        }
    }
    
             
      private void Death()
        {
            gameObject.SetActive(false);
        }
}

