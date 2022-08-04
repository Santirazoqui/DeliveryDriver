using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
    //[SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);

    bool hasPackage;
    [SerializeField] int destroyDelay;

    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("crunch");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("package picked up");
            //SpriteRenderer packageSpriteRenderer = other.GetComponent<SpriteRenderer>();
            spriteRenderer.color = hasPackageColor;//packageSpriteRenderer.Color;
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
        } 
        else if (other.tag == "Customer" && hasPackage == true)
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }


    }
}
