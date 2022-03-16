using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody2D;
    [SerializeField] private float moveSpeed;
    [SerializeField] public float health;
    [SerializeField] public float XpAwarded;

    public float currentHealth;

    private void Start()
    {
        currentHealth = health;    
    }

    void Update()
    {
        //rigidBody2D.velocity = new Vector2(moveSpeed, rigidBody2D.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.tag == "Wall")
        {
            moveSpeed = moveSpeed * -1;

            if (moveSpeed < 0)
            {
                transform.localScale = Vector3.one;
            }
            else if (moveSpeed > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        */
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
            
        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}
