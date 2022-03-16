using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject archerPrefab;
    [SerializeField] GameObject swordsmanPrefab;
    private int player;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerPrefs.GetInt("player");
        if (player == 1)
        {
            archerPrefab.SetActive(true);
        }
        if (player == 0)
        {
            swordsmanPrefab.SetActive(true);
        }
        
    }
}
