using System.Collections;
using System.Collections.Generic;
using Enemies.Controller;
using Enemies.States;
using UnityEngine;

public class AttackState : State
{
    public override void EnterState(EnemyController controller)
    {
            Spit spitComponent = controller.GetComponent<Spit>();

     if (spitComponent != null)
     {
         // Encuentra el jugador usando su etiqueta
          GameObject player = GameObject.FindWithTag("Player");

         if (player != null)
        {
            Collider playerCollider = player.GetComponent<Collider>();

             if (playerCollider != null)
             {
                // Activa el láser
                  spitComponent.FireLaser(playerCollider, true);
                controller.transform.LookAt(player.transform.position);
             }
        }
     }
    }
}
