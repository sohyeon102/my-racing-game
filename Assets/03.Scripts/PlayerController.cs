using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float gas = 100f;
    public float gasConsumptionRate = 10f;
    public TextMeshProUGUI gasText;
    private float gasTimer;
    private Rigidbody2D rb;
    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        UpdateGasUI();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);

        if (rb.position.x > 1.5)
        {
            rb.position = new Vector2(1.5f, rb.position.y);
        }
        else if (rb.position.x < -1.5)
        {
            rb.position = new Vector2(-1.5f, rb.position.y);
        }
        
        GasConsumption();
    }

    void GasConsumption()
    {
        gasTimer += Time.deltaTime;

        if (gasTimer >= 1f)
        {
            gas -= gasConsumptionRate;
            gasTimer = 0f;
            
            Debug.Log(gas);
            UpdateGasUI();


            if (gas <= 0)
            {
                gas = 0;
                gameManager.GameOver();
            }
        }
    }

    public void AddGas(float amount)
    {
        gas += amount;
        if (gas >= 100)
        {
            gas = 100;
        }
        UpdateGasUI();
    }

    void UpdateGasUI()
    {
        gasText.text = $"Gas: {Mathf.Max(0, gas)}";
    }



}
