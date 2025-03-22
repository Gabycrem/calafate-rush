using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Calafate
{
    public class CalafatePlantsPool : MonoBehaviour
    {
        [SerializeField] private CalafatePlant _calafatePlant;
        [SerializeField] private int _poolSize = 10;

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

        public CalafatePlant GetCalafatePlant()
        {
            Debug.Log("GET calafate");
            if(_calafatePool.Count > 0){
                return _calafatePool.Dequeue();
            } else{
                return null;
            }
            
        }

        public void ReturnCalafatePlant(CalafatePlant calafatePlant){
            calafatePlant.gameObject.SetActive(false);
            _calafatePool.Enqueue(calafatePlant);

        }
    }
}

