using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovements : MonoBehaviour
    {
        private Dictionary<KeyCode, Vector3> _movementMap;
        [SerializeField] private Rigidbody _rigidbody = null;
        [SerializeField] private float _speed = 10;
        //[SerializeField] private float _jumpForce = 200;
         [SerializeField] private float _floorDetection;
         [SerializeField] private float _force = 0f;

        /*void Start()
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

        }*/

        // Update is called once per frame
        void Update()
        {
            var movementDirection = Vector3.zero;

            /*foreach (var key in _movementMap.Keys)
            {

                if (Input.GetKey(key))
                {
                    movementDirection += _movementMap[key];
                }
            }*/
            if(Input.GetKey(KeyCode.W))
            {
                movementDirection += transform.forward;
            }
            
            if(Input.GetKey(KeyCode.D))
            {
                movementDirection += transform.right;
            }

            if(Input.GetKey(KeyCode.A))
            {
                movementDirection -= transform.right;
            }

            if (Input.GetKey(KeyCode.S))
            {
                movementDirection -= transform.forward;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var hasCollision = Physics.Raycast(transform.position, Vector3.down, _floorDetection);
               // _rigidbody.AddForce(Vector3.up * _jumpForce);
               if(hasCollision)
               {
                _rigidbody.AddForce(Vector3.up * _force);
               }

            }

            movementDirection = movementDirection.normalized * _speed;
            movementDirection += new Vector3(0, _rigidbody.velocity.y, 0);
            _rigidbody.velocity = movementDirection;

        }

    }

}

