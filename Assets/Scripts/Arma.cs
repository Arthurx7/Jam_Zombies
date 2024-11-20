using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public Transform firePoint;
    public GameObject prefabBala;   
    public AudioSource audioSource;   

    private float tiempoDisparo = 2f;  
    private float tiempoUltimoDisparo = 0f; 

    void Update()
    {

        if (Input.GetButtonDown("Fire1") && Input.GetMouseButton(1))
        {
         
            if (Time.time - tiempoUltimoDisparo >= tiempoDisparo)
            {
                Disparar();  
                tiempoUltimoDisparo = Time.time;  
            }
        }
    }

    void Disparar()
    {
        Instantiate(prefabBala, firePoint.position, firePoint.rotation);  
        audioSource.Play();  
    }
}

