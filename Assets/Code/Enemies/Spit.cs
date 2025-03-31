using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Spit : MonoBehaviour
{

    public Transform hocico;

    public LineRenderer lineRenderer;
    public float laserDuration = 0.5f;

    private void Start()
    {
        lineRenderer.enabled = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            FireLaser(other, true);

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FireLaser(other, false);

        }
    }
    private void Update()

    {

        {



            lineRenderer.SetPosition(0, hocico.position);


        }
    }

     public void FireLaser(Collider target, bool activate)
    {
        if (activate)
        {
            lineRenderer.SetPosition(0, hocico.position);
            lineRenderer.SetPosition(1, target.transform.position);
        }
        lineRenderer.enabled = activate;


    }
}
