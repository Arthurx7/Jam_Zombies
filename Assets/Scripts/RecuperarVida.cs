using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecuperarVida : MonoBehaviour
{
    public Health health; 
    private bool isPlayerInRange = false;

    void Update()
    {
       
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            RecuperarSalud();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            
        }
    }

    private void RecuperarSalud()
    {
            health.VidaPersonaje += 50;
            health.ActualizarBarra();
            Destroy(gameObject);
    }
}
