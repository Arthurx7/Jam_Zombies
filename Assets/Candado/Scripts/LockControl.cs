using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockControl : MonoBehaviour
{
    private int[] result, correctCombination;
    Animator animator;

    public GameObject puerta, candado;
    
    // Start is called before the first frame update
    void Start()
    {
        result = new int[]{0,0,0};
        correctCombination = new int[] {1,2,3};
        RotatePadlock.Rotated += CheckResults;
        animator = this.GetComponent<Animator>();
        
    }

    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "wheel1":
                result[0] = number;
                Debug.Log($"wheel1: result[0] = {result[0]}, number = {number}");
                break;

            case "wheel2":
                result[1] = number;
                Debug.Log($"wheel2: result[1] = {result[1]}, number = {number}");
                break;

            case "wheel3":
                result[2] = number;
                Debug.Log($"wheel3: result[2] = {result[2]}, number = {number}");
                break;
        }
        
        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2])
        {
            Debug.Log("Opened!");
            animator.SetBool("IsOpen", true);
            puerta.SetActive(false);
            candado.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        RotatePadlock.Rotated -= CheckResults;
    }

}
