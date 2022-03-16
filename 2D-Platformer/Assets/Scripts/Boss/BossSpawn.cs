using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public Transform player;
    public Transform spawnPoints;
    public GameObject[] prefab;
    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(wall);
        Instantiate(prefab[0], spawnPoints.position, transform.rotation);
        

    }
}
