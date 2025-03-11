using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovements : MonoBehaviour
    {
        private Dictionary<KeyCode, Vector3> _movementMap;
        [SerializeField] private Rigidbody _rigidbody = null;
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _floorDetection;
        [SerializeField] private float _force = 0f;

        void Start()
        {
            _movementMap = new Dictionary<KeyCode, Vector3>
            {
                {KeyCode.W, Vector3.forward},
                {KeyCode.UpArrow, Vector3.forward},

                {KeyCode.A, Vector3.left},
                {KeyCode.LeftArrow, Vector3.left},

                {KeyCode.S, Vector3.back },
                {KeyCode.DownArrow, Vector3.back },

                {KeyCode.D, Vector3.right },
                {KeyCode.RightArrow, Vector3.right }
            };
        }

        // Update is called once per frame
        void Update()
        {
            var movementDirection = Vector3.zero;
            
            //Obtener rotación actual basada en la rotación del jugador
            foreach (KeyValuePair<KeyCode, Vector3> entry in _movementMap)
            {
                if (Input.GetKey(entry.Key))
                {
                    movementDirection += transform.TransformDirection(entry.Value);
                }
            }

            // Control de salto
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var hasCollision = Physics.Raycast(transform.position, Vector3.down, _floorDetection);
                if (hasCollision)
                {
                    _rigidbody.AddForce(Vector3.up * _force);
                }
            }

            //Aplicando movimiento
            movementDirection = movementDirection.normalized * _speed;
            movementDirection += new Vector3(0, _rigidbody.velocity.y, 0);
            _rigidbody.velocity = movementDirection;

        }

    }

}

