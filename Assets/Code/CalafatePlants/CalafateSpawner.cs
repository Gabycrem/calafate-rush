using System.Collections;
using TerrainM;
using UnityEngine;


namespace Calafate
{
    public class CalafateSpawner : MonoBehaviour
    {
        [SerializeField] private float _spwanInterval = 5f;
        [SerializeField] private float _timeToLive = 15f;
        private float _spawnTimer = 0f;
        [SerializeField] private CalafatePlantsPool _calafatePlantsPool;
        private TerrainManager _terrainManager;

        private void Start()
        {
            _terrainManager = FindObjectOfType<TerrainManager>();
            if (_terrainManager == null){
                Debug.LogError("No se encontró TerrainManager en la escena.");
            }
        }
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
            //Controlando que exista Terrain
            if (_terrainManager == null){
                Debug.LogError("TerrainManager no está inicializado.");
                return;
            }

            //Busco posición
            Vector3 spawnPosition = _terrainManager.GetTerrainArea();

            // Traer una planta del Queue pool
            CalafatePlant calafatePlant = _calafatePlantsPool.GetCalafatePlant();

            if (calafatePlant != null)
            {
                calafatePlant.transform.position = spawnPosition;

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

