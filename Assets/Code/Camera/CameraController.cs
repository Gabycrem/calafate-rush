
using UnityEngine;

namespace Assembly_CSharp.Assets.Code.Camera
{

  public class CameraController : MonoBehaviour
  {
    [SerializeField] private Transform _player;
    [SerializeField] private float _mouseSensibility = 1f;
    private float currentYRotation = 0;

    void Start()
    {
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
      var mouseX = Input.GetAxis("Mouse X") * _mouseSensibility;
      var mouseY = Input.GetAxis("Mouse Y") * _mouseSensibility;

      //Rotación en el eje X (vertical)
      //Se invierte para que se mueva en la dirección correcta al mover el mouse
      currentYRotation -= mouseY;
      // Limitamos el valor para evitar rotación infinita
      currentYRotation = Mathf.Clamp(currentYRotation, -90, 90);
      transform.localRotation = Quaternion.Euler(currentYRotation, 0, 0);

      //Rotación en el eje Y (horizontal)
      _player.Rotate(0, mouseX, 0);
    }
  }
}