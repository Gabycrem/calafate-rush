
using System.Collections;
using System.Numerics;
using Assembly_CSharp.Assets.Code.WeaponsSystem.Proyectiles;
using UnityEngine;

namespace Calafate
{
    public class CalafatePlant : MonoBehaviour
    {
        [SerializeField] private GameObject _plantWithFruits;
        [SerializeField] private GameObject _plantWithoutFruits;
        [SerializeField] private float _regenerationTime = 5f;


        // Recibe disparo. Oculta frutos en la planta. 
        // Próx: hacer aparecer frutos caidos. si el player esta a una cierta distancia 
        void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.TryGetComponent<Proyectile>(out _))
            {
                // Ocultar la planta con frutos y mostrar la sin frutos
                ChangePlantState(false);
                Debug.Log("le pego");

                //Soltar los frutos

                //DropFruits();

                // Destruir el proyectil
                Destroy(collision.gameObject);

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
