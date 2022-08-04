using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("crunch");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package")
        {
            Debug.Log("package picked up");
            hasPackage = true;
        } 
        else if (other.tag == "Customer" && hasPackage == true)
        {
            Debug.Log("Package delivered");
            hasPackage = false;
        }


    }
}
