using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;
    public float speed = 5f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    public Animator animator; // Referencia al Animator
    private bool isRunning; // Estado de correr

    public float runSpeed = 8f; // Velocidad al correr
    public float walkSpeed = 5f; // Velocidad al caminar

    private void OnEnable()
    {
        CameraSwitcher.OnCameraChanged += UpdateCameraTransform;
    }

    private void OnDisable()
    {
        CameraSwitcher.OnCameraChanged -= UpdateCameraTransform;
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); // Asignar el Animator
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Determinar si el jugador está corriendo
        isRunning = Input.GetKey(KeyCode.LeftShift);
        speed = isRunning ? runSpeed : walkSpeed;

        if (direction.magnitude >= 0.1f)
        {
            // Movimiento y rotación
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            // Actualizar animaciones de caminar o correr
            animator.SetFloat("Velocidad", isRunning ? 1f : 0.5f, 0.1f, Time.deltaTime);
        }
        else
        {
            // Si no hay movimiento, detener animación
            animator.SetFloat("Velocidad", 0f, 0.1f, Time.deltaTime);
        }
    }

    private void UpdateCameraTransform(Transform newCameraTransform)
    {
        cameraTransform = newCameraTransform;
    }
}
