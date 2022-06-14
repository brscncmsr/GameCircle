using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopController : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Debug.Log((pos));
            Destroy(collision.gameObject);
            
        }
        
    }
}
