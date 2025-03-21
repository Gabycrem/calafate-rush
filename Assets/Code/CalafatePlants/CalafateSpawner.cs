using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Calafate
{
    public class CalafateSpawner : MonoBehaviour
    {
        [SerializeField] private float _spwanInterval = 5f;
        [SerializeField] private float _timeToLive = 15f;
        private float _spawnTimer = 0f;

        [SerializeField] private CalafatePlantsPool _calafatePlantsPool;

        private void Update()
        {
            Debug.Log("Inicio Update");
            _spawnTimer += Time.deltaTime; //tiempo real transcurrido
            if (_spawnTimer >= _spwanInterval)
            {
                _spawnTimer = 0f;
                SpawnCalafate();
            }
        }

        private void SpawnCalafate()
        {
            Debug.Log("Inicio SpawnCalafate");
            // Traer una planta del Queue pool
            CalafatePlant calafatePlant = _calafatePlantsPool.GetCalafatePlant();

            if (calafatePlant != null)
            {
                float randomX = Random.Range(-10f, 10f);
                float randomY = Random.Range(0f, 5f);
                calafatePlant.transform.position = new Vector3(randomX, randomY, -20f);

                // Activo la planta
                calafatePlant.gameObject.SetActive(true);

                //Desactivo después del tiempo establecido de vida
                StartCoroutine(DesactivateAfterTime(calafatePlant));
            }
        }

        private IEnumerator DesactivateAfterTime(CalafatePlant calafatePlant)
        {
            yield return new WaitForSeconds(_timeToLive);
            _calafatePlantsPool.ReturnCalafatePlant(calafatePlant);
        }
    }
}

