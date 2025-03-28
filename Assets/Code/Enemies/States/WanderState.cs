using System.Collections;
using System.Collections.Generic;
using Enemies.Controller;
using Enemies.States;
using UnityEngine;
namespace Enemies.States
{
    public class WanderState : State
    {   
        private int _waypointIndex = 0;
        private Vector3 _nextWaypoint = Vector3.zero;
         public override void EnterState(EnemyController controller )
         {  
            if(controller.Waypoints.Length <= 0)
            {
                return;
            }
            SetNewDestination(controller);
         }

           public override void  UpdateState (EnemyController controller )
         {  
            if(Vector3.Distance(controller.transform.position, _nextWaypoint) > 3)
            {
                return;
            }
            _waypointIndex++;
            SetNewDestination(controller);
         }

         public override void ExitState (EnemyController controller )
         {
            base.ExitState(controller);
            controller.Agent.ResetPath();
         }
         private void SetNewDestination(EnemyController controller)
         {
            if(controller.Waypoints.Length <= _waypointIndex)   
            {
                _waypointIndex = 0;
            }

            _nextWaypoint = controller.Waypoints[_waypointIndex].position;
            controller.Agent.SetDestination(_nextWaypoint);
         }

    }   

}