using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;
    private float spawnInterval = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Don't allow spawn intervals that are too long to be configured in the UI
        if (spawnInterval <= 3f || spawnInterval >= 5f){
            spawnInterval = Random.Range(3f, 5f);
        }
    }

    void Update(){
        if (spawnInterval <= 0f){
            SpawnRandomBall();
            spawnInterval = Random.Range(3f, 5f);
        }
        spawnInterval -= Time.deltaTime;
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        // Pick which ball using a random number generator.  Hoping that the overload Random.Range(int lower, int upper) is non-inclusive of the upper bound per documentation.
        int ballIndex = Random.Range(0,ballPrefabs.Length);
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }

}
