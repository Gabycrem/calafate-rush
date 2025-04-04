using System.Collections;
using System.Collections.Generic;
using Enemies.States;
using UnityEngine;
using UnityEngine.AI; 
namespace Enemies.Controller
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        [Header("Waypoints para patrullaje")]
        [SerializeField] private Transform[] _waypoints;

     
    public NavMeshAgent Agent => _agent;
    public Transform[] Waypoints => _waypoints;
    private Transform _target;  
    private State _currentState;

    //State
    private WanderState _wanderState = new WanderState();
    private AttackState _attackState = new AttackState();

        private void Start()
        {
            SetNewState(_wanderState);
        }

        private void Update()
    {
          if(_currentState != null)
          {
            _currentState.UpdateState(this);
          }
    } 
    public void DetectPlayer(Transform player)
    {
        _target = player;
        SetNewState(_attackState);
       // _agent.SetDestination(player.position); //encontrar el camino mas rapido al player
        transform.LookAt(player);
        //transform.localRotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y, 0);
    }
    public void LeavePlayer()
    {
        _target = null;
        SetNewState(_wanderState);
    }
    public void SetNewState(State state)
    {
        if(_currentState != null)
        {
            _currentState.ExitState(this);
        }

        _currentState = state;
        _currentState.EnterState(this);
    }

    public void ChasePlayer()
{
    if (_target != null) // Asegúrate de que el jugador está siendo detectado
    {
        float distance = Vector3.Distance(transform.position, _target.position);
        

        // Si la distancia es mayor que un límite establecido, persigue al jugador
        if (distance > 2.0f && distance < 100.0f) // Rango ajustable
        {
            _agent.SetDestination(_target.position);
        }
        else if (distance >= 100.0f) // Si el jugador está muy lejos, cancela el ataque
        {
            LeavePlayer(); // Regresa a patrullaje si está fuera del alcance
        }
    }
}

public void RotateTowardsPlayer()
{
    if (_target != null)
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}




}
}