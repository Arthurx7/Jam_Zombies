using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenesManager : MonoBehaviour
{
    [SerializeField] string sceneToLoad; 

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) 
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
