using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
    public Transform hocico;
    public LineRenderer lineRenderer;
    public float laserDuration = 0.5f;

    private Transform currentTarget; // Para almacenar la referencia al jugador

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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FireLaser(false);
            currentTarget = null; // Eliminamos la referencia al jugador
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
        }
    }
}
