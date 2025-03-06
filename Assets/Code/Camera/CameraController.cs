using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


namespace Assembly_CSharp_Editor.Assets.CODE.Camera
{
     public class CameraController : MonoBehaviour
     { 
       [SerializeField] private Transform _player; 
       [SerializeField] private float _mouseSensibility = 1f;
       private float currentYRotation = 0;
      
       void Start()
       {
        Cursor.visible = false;
       }

       
       void Update()

       {
          var mouseX = Input.GetAxis("Mouse X") * _mouseSensibility;
          var mouseY = Input.GetAxis("Mouse Y") * _mouseSensibility;
          
        
          //ivertimos en valor para poder rotar en la direccion correcta al mover el mouse
          currentYRotation -= mouseY;
          //limitamos el valor entre -90 y +90 para evitar una rotacion infinita en el eje x
          currentYRotation = Mathf.Clamp(currentYRotation, -90, 90);

           //rotate camera:
          transform.localRotation = UnityEngine.Quaternion.Euler(currentYRotation, 0, 0);
          //rotate the player
          _player.Rotate(0, mouseX, 0); //aqui le decimos que va a girar sobre el eje y cuando el mouse se mueve en eje x
          
        }
         
    }
}
