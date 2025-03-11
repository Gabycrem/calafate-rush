
using Assembly_CSharp.Assets.Code.WeaponsSystem.Proyectiles;
using UnityEngine;

namespace WeaponsSystem
{


    public class Weapon : MonoBehaviour
    {
      [SerializeField] private Proyectile  _proyectile;
      [SerializeField] private Transform _spawnPosition; 
      [SerializeField] private float _force = 10;

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
// en weapon estoy referenciando el c# del proyectil  ( estoy referenciando al script, no al gameobject )y este contiene el rigidbody 