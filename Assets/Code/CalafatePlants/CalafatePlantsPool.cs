using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Calafate
{
    public class CalafatePlantsPool : MonoBehaviour
    {
        [SerializeField] private CalafatePlant _calafatePlant;
        [SerializeField] private int _poolSize = 20;
        [SerializeField] private float _spwanInterval = 5f;
        [SerializeField] private float _timeToLive = 15f;
        private float _spawnTimer = 0f;
        private Queue<CalafatePlant> _calafatePool = new();
        void Start()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                CalafatePlant calafate = Instantiate(_calafatePlant);
                calafate.gameObject.SetActive(false);
                _calafatePool.Enqueue(calafate);
            }
        }

        void Update()
        {
            _spawnTimer += Time.deltaTime; //tiempo real transcurrido
            if (_spawnTimer >= _spwanInterval)
            {
                _spawnTimer = 0f;
                
            }
        }


    }
}

