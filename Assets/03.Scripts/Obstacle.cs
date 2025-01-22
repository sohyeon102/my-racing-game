using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float moveSpeed = 10f;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    
    private void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameManager.GameOver();
            Destroy(gameObject);
        }
    }
}
