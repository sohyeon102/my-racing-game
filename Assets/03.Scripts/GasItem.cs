using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasItem : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    private void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().AddGas(30f);
            Destroy(gameObject);
        }
    }
}
