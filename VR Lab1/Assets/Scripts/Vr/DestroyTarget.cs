using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletHead"))
        {
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
