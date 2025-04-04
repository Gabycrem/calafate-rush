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
                // Primero rota hacia el jugador
                 controller.RotateTowardsPlayer();
                // Activa el láser
                  spitComponent.FireLaser(true);
                
             }
        }
     }


    
    

    public override void UpdateState(EnemyController controller)
    {
    // Perseguir al jugador si está en rango
    controller.ChasePlayer();

    // Mantener la rotación hacia el jugador
    controller.RotateTowardsPlayer();
    }
}

       /* public override void UpdateState(EnemyController controller)
        {
             GameObject player = GameObject.FindWithTag("Player");

                 if (player != null)
                 {
                            // Actualiza la rotación para mirar al jugador
                           Vector3 direction = (player.transform.position - controller.transform.position).normalized;
                            controller.transform.rotation = Quaternion.LookRotation(direction);
                 }
        }*/




