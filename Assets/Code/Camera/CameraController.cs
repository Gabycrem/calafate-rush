using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.Code.Camera
{

  public class CameraController: MonoBehaviour
  {
    [SerializeField] private Transform _player;
    [SerializeField] private float _mouseSensibility = 1f;

    private float currentYRotation = 0;
      
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
     void Update()
     {
        var mouseX = Input.GetAxis("Mouse X") * _mouseSensibility;
        var mouseY = Input.GetAxis("Mouse Y") * _mouseSensibility;

        currentYRotation -= mouseY;
        currentYRotation = Mathf.Clamp(currentYRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(currentYRotation, 0, 0);
        _player.Rotate(0, mouseX, 0);
     }
  }
}