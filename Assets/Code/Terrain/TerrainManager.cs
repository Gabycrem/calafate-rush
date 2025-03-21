using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TerrainM
{
    public class TerrainManager : MonoBehaviour
    {
        private Collider _terrainCollider;
        private void Start()
        {
            _terrainCollider = GetComponent<Collider>();
            if (_terrainCollider == null)
            {
                Debug.LogError("No se encontró un Colider en la escena.");
            }
            else
            {
                Debug.Log("LowPoly Terrain detectado");
            }
        }

        public Vector3 GetTerrainArea()
        {
            //Límites del terreno 
            Bounds bounds = _terrainCollider.bounds;

            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomZ = Random.Range(bounds.min.z, bounds.max.z);
            //Lanzamos raycast de un poco más arriba
            float rayCastStarY = bounds.max.y + 10f;

            Vector3 rayStart = new Vector3(randomX, rayCastStarY, randomZ);
            RaycastHit hit;

            //Disparamos RayCast desde arriba hacia abajo
            if (Physics.Raycast(rayStart, Vector3.down, out hit, Mathf.Infinity))
            {
                //Si golpea algo devuelve la posicion exacta
                return hit.point;
            }
            //Si falla, usa la base del terreno.
            return new Vector3(randomX, bounds.min.y, randomZ);
        }

    }
}

