using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
     //Camaras
    //public GameObject camara2;

    private CharacterController controller;

    public static float veloMovi = 2.0f;
    public float veloRota = 10f;

    public static float X, Z;
    bool running;
    
    [SerializeField] private Camera followCamera;

    private Vector3 veloJugador;
    public Transform checkPiso;
    public float distanciaPiso = 0.4f;
    public LayerMask piso;
    public float gravedad = -9.81f;
    //public float salto = 1f;

    public Animator animator;

    bool enPiso;

    //public Item itemArma; 
    //public Item itemLinterna;

    //public Player vidaJugador;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //camara2.SetActive(false);

    }

    void Update()
     {
        MovimientoPlayer();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            running=true; 
            animator.SetBool("Run",true);

        } else 
        {
            animator.SetBool("Run",false);
            running = false;
        }

        //if(itemLinterna.equipado == true && Input.GetMouseButton(1) || itemArma.equipado == true && Input.GetMouseButton(1)  )
        //{
            //animator.SetBool("Armado", true); 
            //camara2.SetActive(true);
            //followCamera.enabled = false;
        //}
        //else
        //{
             //animator.SetBool("Armado", false); 
             //camara2.SetActive(false);
            //followCamera.enabled = true;
        //}

        //if (Input.GetKeyDown(KeyCode.Z))
        //{
            //animator.SetBool("Roll", true);
            
        //} else {animator.SetBool("Roll", false); }

        // }Debug.Log(running);

        // animator.SetFloat("VelX",X);
        // animator.SetFloat("VelZ",Z);
    }

    public void MovimientoPlayer()
    {
         if(running)
        {
            veloMovi = 5f;
        }
        else 
        {
            veloMovi = 2f;
        }

        enPiso = Physics.CheckSphere(checkPiso.position, distanciaPiso, piso);

        if (enPiso && veloJugador.y < 0)
        {
            veloJugador.y = -2f;

        }

        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");

        Vector3 moveInput = Quaternion.Euler(0, followCamera.transform.eulerAngles.y, 0) * new Vector3(X, 0, Z);

        Vector3 moveDirection = moveInput.normalized;

        controller.Move(moveDirection * veloMovi * Time.deltaTime);

        if(moveDirection != Vector3.zero && running == false)
        {
            Quaternion rotacion = Quaternion.LookRotation(moveDirection, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, veloRota * Time.deltaTime);

            animator.SetFloat("Velocidad", Movimiento.veloMovi, 0.1f, Time.deltaTime);
        }

        else if(moveDirection != Vector3.zero && running)
        {
            Quaternion rotacion = Quaternion.LookRotation(moveDirection, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, veloRota * Time.deltaTime);

            animator.SetFloat("Velocidad", Movimiento.veloMovi, 0.1f, Time.deltaTime);

        }
        else 
        {
           animator.SetFloat("Velocidad", 0, 0.1f, Time.deltaTime);
        }

        //if(Input.GetButtonDown("Jump") && enPiso)
        //{
        //    veloJugador.y = Mathf.Sqrt(salto * 2f * gravedad);
        //}

        veloJugador.y += gravedad * Time.deltaTime;
        controller.Move(veloJugador * Time.deltaTime);

    }
}
