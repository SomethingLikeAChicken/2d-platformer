using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionObstacles : MonoBehaviour
{   private int maxHealth = 100;     //Health from Player
    private int currentHealth;

    public int xp;                   //Player Experience and Levels
    public int xpNeeded = 100;
    private int level;

    [SerializeField] public HealthBar healthbar;
    [SerializeField] private int healingAmt;
    // Start is called before the first frame update
    void Start()
    { 
        //spriteRenderer.GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentHealth < 1){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "Obstacle"){
            TakeDamage(20);
        }
        if(other.gameObject.tag == "Medkit"){
            TakeMedkit(healingAmt);
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Boss"){
            TakeDamage(30);
        }
    }
    public void TakeDamage(int damage){
        
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
    void TakeMedkit(int heal){
        currentHealth += heal;
        healthbar.SetHealth(currentHealth);
        
    }
    void addExperience(int xp)
    {
        this.xp = xp;

        if(xp >= xpNeeded)
        {
            level++;
            xp = 0;
        }
    }
}
