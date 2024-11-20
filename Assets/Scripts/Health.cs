using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float VidaPersonaje = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecibirDaño(){
        VidaPersonaje -= 5f;
        print("Daño recibido, vida actual: "+VidaPersonaje);
    }
}
