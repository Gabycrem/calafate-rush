using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
    public Transform hocico;
    public LineRenderer lineRenderer;
    public float laserDuration = 0.3f;
   
    private Transform currentTarget; // Para almacenar la referencia al jugador
    [SerializeField] private float _damage = 1;
    private bool isFiringLaser = false; // Indica si el láser está activo

    private void Start()
    {
        lineRenderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentTarget = other.transform; // Guardamos la referencia al jugador
            FireLaser(true);
            StartCoroutine(DealDamageOverTime(other.GetComponent<PlayerHealth>()));// Empieza a causar daño
            Debug.Log("le esta hacinedo daño");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FireLaser(false);
            currentTarget = null; // Eliminamos la referencia al jugador
            isFiringLaser = false; // Detenemos el daño
        }
    }

    private void Update()
    {
        if (lineRenderer.enabled && currentTarget != null)
        {
            // Actualizamos las posiciones del LineRenderer
            lineRenderer.SetPosition(0, hocico.position);
            lineRenderer.SetPosition(1, currentTarget.position);
        }
    }

    public void FireLaser(bool activate)
    {
        lineRenderer.enabled = activate;

        if (activate && currentTarget != null)
        {
            // Configuramos las posiciones inicial y final del láser
            lineRenderer.SetPosition(0, hocico.position);
            lineRenderer.SetPosition(1, currentTarget.position);
            isFiringLaser = true; // Indicamos que el láser está disparando
        }
    }

     private IEnumerator DealDamageOverTime(PlayerHealth playerHealth)
    {
        while (isFiringLaser && playerHealth != null)
        {
            playerHealth.TakeDamage(_damage); // Causa daño al jugador
            yield return new WaitForSeconds(laserDuration); // Espera antes de volver a causar daño
        }
    }

}
