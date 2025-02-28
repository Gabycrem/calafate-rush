using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovements : MonoBehaviour
    {
        private Dictionary<KeyCode, Vector3> _movementMap;
        [SerializeField] private Rigidbody _rigidbody = null;
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _jumpForce;



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

            foreach (var key in _movementMap.Keys)
            {

                if (Input.GetKey(key))
                {
                    movementDirection += _movementMap[key];
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce);
            }

            movementDirection = movementDirection.normalized * _speed;
            movementDirection += new Vector3(0, _rigidbody.velocity.y, 0);
            _rigidbody.velocity = movementDirection;


        }

    }

}

