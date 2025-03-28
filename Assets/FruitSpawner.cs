using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _fruitPrefab;
    [SerializeField] private int _amountOfFruitsSpawn = 7;
    
    public void SpawnFruits()
    {
        List<GameObject> fruits = new();
        for(int i = 0; i<_amountOfFruitsSpawn; i++)
        {
            GameObject fruit = Instantiate(_fruitPrefab, transform);
            fruits.Add(fruit);
        }
        PushFruits();
    }

    private void PushFruits()
    {
        
    }
}
