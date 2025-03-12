
using UnityEngine;

namespace Calafate
{
    public class CalafatePlant : MonoBehaviour
    {
        public GameObject PlantWithFruits;
        public GameObject PlantWithoutFruits;
        void Start()
        {
            PlantWithFruits.SetActive(true);
            PlantWithoutFruits.SetActive(false);
        }

        void Update()
        {

        }
    }

}
