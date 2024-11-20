using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    public Animator animator;
    private bool isRunning;
    private bool isAiming;

    public float runSpeed = 8f;      // Velocidad al correr
    public float walkSpeed = 5f;    // Velocidad al caminar
    public float aimWalkSpeed = 3f; // Velocidad al caminar apuntando
    public float aimRunSpeed = 5f;  // Velocidad al correr apuntando

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
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Determinar estados
        isRunning = Input.GetKey(KeyCode.LeftShift);
        isAiming = Input.GetMouseButton(1);

        // Configurar velocidad según estado
        float currentSpeed;
        if (isAiming)
        {
            currentSpeed = isRunning ? aimRunSpeed : aimWalkSpeed;
        }
        else
        {
            currentSpeed = isRunning ? runSpeed : walkSpeed;
        }

        // Actualizar parámetros del Animator
        animator.SetBool("Run", isRunning);
        animator.SetBool("Apuntar", isAiming);

        if (direction.magnitude >= 0.1f)
        {
            // Movimiento
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);

            // Normalizar la velocidad del Animator
            animator.SetFloat("Velocidad", direction.magnitude, 0.1f, Time.deltaTime);
        }
        else
        {
            // Detener animación de movimiento
            animator.SetFloat("Velocidad", 0f, 0.1f, Time.deltaTime);
        }
    }

    private void UpdateCameraTransform(Transform newCameraTransform)
    {
        cameraTransform = newCameraTransform;
    }
}
