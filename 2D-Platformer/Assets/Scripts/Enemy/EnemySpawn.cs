using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform player;
    public Transform spawnPoints;
    public GameObject prefab;
    public int cooldown = 100;

    private bool boolDebounce = false;
    private int intDebounce;

    private void Update()
    {
        if (boolDebounce)
        {
            intDebounce--;
            if (intDebounce == 0)
            {
                boolDebounce = false;
            }
        }
    }

    void Start()
    {
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!boolDebounce)
        {
            Instantiate(prefab, spawnPoints.position, transform.rotation);
            intDebounce = cooldown;
            boolDebounce = true;
        }
    }
}
