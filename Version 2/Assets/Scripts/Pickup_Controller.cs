using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Controller : MonoBehaviour
{
    public Transform[] spawnPoints;
    private int lastSpawnIndex;

    public GameObject pickup;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
        spawnPickup();
    }
    
    public void spawnPickup() {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        while (spawnIndex == lastSpawnIndex) {
            spawnIndex = Random.Range(0, spawnPoints.Length);
        }
        lastSpawnIndex = spawnIndex;
        Instantiate(pickup, spawnPoints[spawnIndex].position, Quaternion.identity);
    }
}
