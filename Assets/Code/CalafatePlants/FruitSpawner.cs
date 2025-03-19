using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calafate
{
    public class FruitSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _fruitPrefab;
        [SerializeField] private int _amountOfFruitsSpawn = 7; // Cantidad de frutos que creamos
        [SerializeField] private float _jumpForce = 3f; // Fuerza hacia arriba
        [SerializeField] private float _horizontalForce = 1f; // Variación horizontal
        [SerializeField] private float _forwardForce = 1f; // Fuerza hacia adelante
        [SerializeField] private float _timeToDeleteFruits = 5f; // Tiempo de vida de los frutos caídos

        public List<GameObject> Fruits = new();
        public void SpawnFruits()
        {
            Debug.Log("Estoy en el SpawnFruits()");
            for (int i = 0; i < _amountOfFruitsSpawn; i++)
            {
                GameObject fruit = Instantiate(_fruitPrefab, transform);
                Fruits.Add(fruit);
            }
            PushFruits();

            //Corrutina para hacer desaparecer los frutos caidos despues de un tiempo
            StartCoroutine(DeleteFruits());
        }

        private void PushFruits()
        {
            foreach (GameObject fruit in Fruits)
            {
                Rigidbody rb = fruit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    // Genera un impulso aleatorio en X y Z para dispersión
                    float randomX = Random.Range(-_horizontalForce, _horizontalForce);
                    float randomZ = Random.Range(-_forwardForce, _forwardForce);

                    // Aplica la fuerza hacia arriba y en dirección aleatoria
                    Vector3 force = new Vector3(randomX, _jumpForce, randomZ);
                    rb.AddForce(force, ForceMode.Impulse);
                }
            }
        }

        private IEnumerator DeleteFruits(){
            yield return new WaitForSeconds(_timeToDeleteFruits);
            foreach(GameObject fruit in Fruits){
                if (fruit != null){
                    Destroy(fruit);
                }
            }
            Fruits.Clear();
        }
    }
}

