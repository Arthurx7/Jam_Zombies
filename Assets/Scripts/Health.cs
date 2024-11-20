using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float VidaPersonaje = 100f;
    public Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecibirDaño(){
        VidaPersonaje -= 10f;
        ActualizarBarra();
    }

    public void ActualizarBarra(){
         healthSlider.value = VidaPersonaje;
    }
}
