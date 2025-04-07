using System.Collections;
using System.Collections.Generic;
using Enemies.Controller;
using UnityEngine;
namespace Enemies.Triggers
{
    public class PlayerDetector : MonoBehaviour
    {
        [SerializeField ] private EnemyController _enemyController;
       
     
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                
                _enemyController.DetectPlayer(other.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        
        {
            if(other.CompareTag("Player"))

            {
                _enemyController.LeavePlayer();
            }


         }
    }
}