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
        // Obt�n el componente Animator del GameObject
        animator = GetComponent<Animator>();

        // Obt�n el componente Rigidbody del GameObject
        rb = GetComponent<Rigidbody>();

        // Verifica si el Animator existe y comienza la animaci�n "Run" con loop habilitado
        if (animator != null)
        {
            animator.Play("RUN");
        }

        if (animator != null)
        {
            // Aseg�rate de que el loop est� habilitado en cada frame
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("RUN") && !stateInfo.loop)
            {
                // Activa el loop en tiempo de ejecuci�n si no estaba activado
                animator.SetBool("Loop", true);
            }
        }
    }


    void FixedUpdate()
    {
        // Aplica fuerza hacia adelante mientras se ejecuta la animaci�n "RUN"
        if (animator != null && animator.GetCurrentAnimatorStateInfo(0).IsName("RUN"))
        {
            transform.Translate(Vector3.forward * runForce * Time.deltaTime);

           

        }
    }


}