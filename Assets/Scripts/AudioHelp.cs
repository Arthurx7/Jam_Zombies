using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHelp : MonoBehaviour
{
        [SerializeField] private AudioSource audioSource;
        private bool yaseDijo = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !yaseDijo)
        {
            yaseDijo = true;
            audioSource.Play();
        }
    }
}
