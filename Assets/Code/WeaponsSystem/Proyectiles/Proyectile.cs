using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.Code.WeaponsSystem.Proyectiles
{
    public class Proyectile : MonoBehaviour
    {
        //EL PROYECTIL VA A TENER REFENCIA AL RIGIDBODY
        [SerializeField] private Rigidbody _rigidbody;
        
        void Start()
        {
            StartCoroutine(WaitingLife());
        }

        public void Shoot(float force, Vector3 direction)
        //necesitamos como parametro fuerza y direccion 
        {
            _rigidbody.velocity = direction * force;

        }

        //Corrutina, las declaramos siempre con el IEnumerator usando la libreria System.Collections;
        private IEnumerator WaitingLife()
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }
    }
}