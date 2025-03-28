using System.Collections;
using Assembly_CSharp.Assets.Code.WeaponsSystem.Projectiles;
using UnityEngine;
using WeaponsSystem;

namespace Calafate
{
    public class CalafatePlant : MonoBehaviour
    {
        [SerializeField] private GameObject _plantWithFruits;
        [SerializeField] private GameObject _plantWithoutFruits;
        [SerializeField] private float _regenerationTime = 5f;


        // Recibe disparo. Oculta frutos en la planta. 
        // Ya aparecen los frutos caidos.
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnCollisionEnter");
            if (other.gameObject.TryGetComponent<Projectile>(out var projectile))
            {
                //Soltar los frutos
                if (_plantWithFruits.activeSelf) //Verifico que la planta activa es la que tiene frutos.
                {
                    FruitSpawner spawner = GetComponentInChildren<FruitSpawner>(); // Obtiene el Spawner en esta planta
                    if (spawner != null)
                    {
                        Debug.Log("activa Spawner");
                        spawner.SpawnFruits();  // Activa el Spawner de esta planta
                    }
                }

                // Ocultar la planta con frutos y mostrar la sin frutos
                ChangePlantState(false);
                Debug.Log("le pego");

                // Devolver el proyectil al pool
                ProjectilePool.Instance.Return(projectile);

                //Iniciar regeneración de frutos
                StartCoroutine(RegenerateFruits());
            }
        }

        // Regeneración de Frutos
        IEnumerator RegenerateFruits()
        {
            yield return new WaitForSeconds(_regenerationTime);
            ChangePlantState(true);
        }

        // Función para cambiar el estado de la planta
        void ChangePlantState(bool hasFruits)
        {
            _plantWithFruits.SetActive(hasFruits);
            _plantWithoutFruits.SetActive(!hasFruits);
        }

        //Función para soltar los frutos
        /*
        void DropFruits()
        {
            
        }
        */
    }
}
