using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BulletHead"))
        {
            Debug.Log("Recibe la colision");
            collision.gameObject.GetComponent<DeactivateBullets>().DisableProjectileInmediately();

            //Increment Score 

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletHead"))
        {
            Debug.Log("Recibe el trigger");
            other.gameObject.GetComponent<DeactivateBullets>().DisableProjectileInmediately();

            //Increment Score 

            Destroy(gameObject);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
