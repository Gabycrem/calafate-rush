using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Code.WeaponsSystem.Proyectiles;
using UnityEngine;

namespace WeaponsSistem
{


    public class Weapon : MonoBehaviour
    {
      [SerializeField] private Proyectile  _proyectile;
      [SerializeField] private Transform _spawnPosition; 
      [SerializeField] private float _force = 10;

       // Start is called before the first frame update
       void Start()
       {
        
       }
 
       // Update is called once per frame
       void Update()
       {
        if(Input.GetMouseButtonDown(0))
        {
          /*Debug.Log("Instantiate proyectile"); //instanciar el proyectil (generar copia)
          Instantiate(_proyectile, _spawnPosition.position, Quaternion.identity);*/

          //
          var proyectileInstance = Instantiate(_proyectile, _spawnPosition.position, Quaternion.identity);
          proyectileInstance.Shoot(_force, transform.forward);
        }
       }
    }
}
// en weapon estoy referenciando el c# del proyectil  ( estoy referenciando al script, no algameobject )y este contiene el rigidbody 