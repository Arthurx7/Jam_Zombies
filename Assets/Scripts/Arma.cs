using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public Transform firePoint;
    public GameObject prefabBala;


   
   // public Mov3Person mv;

    private float tiempoDisparo = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           // mv.animator.SetBool("DisparoParado", true);
            Disparar();
        }
    }

    void Disparar()
    {
       Instantiate(prefabBala, firePoint.position, firePoint.rotation);        
    }
}
