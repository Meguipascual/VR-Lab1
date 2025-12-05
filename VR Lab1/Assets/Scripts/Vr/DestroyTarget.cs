using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTarget : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Recibe el trigger");
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("BulletHead"))
        {
            other.gameObject.GetComponent<DeactivateBullets>().DisableProjectileInmediately();

            //Increment Score 

            Destroy(gameObject);
        }    
    }
}
