
using System.Collections;
using System.Numerics;
using UnityEngine;

namespace Calafate
{
    public class CalafatePlant : MonoBehaviour
    {
        public GameObject PlantWithFruits;
        public GameObject PlantWithoutFruits;
        [SerializeField] private float _regenerationTime = 5f;


        // Recibe disparo. Oculta frutos en la planta. 
        // Próx: hacer aparecer frutos caidos. si el player esta a una cierta distancia 
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Projectile"))
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
            PlantWithFruits.SetActive(hasFruits);
            PlantWithoutFruits.SetActive(!hasFruits);
        }

        //Función para soltar los frutos
        /*
        void DropFruits()
        {
            
        }
        */
    }
}
