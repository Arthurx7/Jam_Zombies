using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{    public CinemachineVirtualCamera activeCam;

    public delegate void CameraChanged(Transform newCameraTransform);
    public static event CameraChanged OnCameraChanged;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activeCam.Priority = 1;
            OnCameraChanged?.Invoke(activeCam.transform); // Notificar el cambio de cámara
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activeCam.Priority = 0;
        }
    }
}
