using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartRunAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb; // Referencia al Rigidbody
    public float runForce = 10f; // Magnitud de la fuerza aplicada al correr

    void Start()
    {
        // Obtén el componente Animator del GameObject
        animator = GetComponent<Animator>();

        // Obtén el componente Rigidbody del GameObject
        rb = GetComponent<Rigidbody>();

        // Verifica si el Animator existe y comienza la animación "Run" con loop habilitado
        if (animator != null)
        {
            animator.Play("RUN");
        }

        if (animator != null)
        {
            // Asegúrate de que el loop está habilitado en cada frame
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("RUN") && !stateInfo.loop)
            {
                // Activa el loop en tiempo de ejecución si no estaba activado
                animator.SetBool("Loop", true);
            }
        }
    }


    void FixedUpdate()
    {
        // Aplica fuerza hacia adelante mientras se ejecuta la animación "RUN"
        if (animator != null && animator.GetCurrentAnimatorStateInfo(0).IsName("RUN"))
        {
            transform.Translate(Vector3.forward * runForce * Time.deltaTime);

           

        }
    }


}