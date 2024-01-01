using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ObstacleSpawnScript : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private float timer = 0f;
    private float spawnTime = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnTime)
        {
            timer = 0f;
            spawnObstacle();
        }
    }

    private void spawnObstacle()
    {
        GameObject.Instantiate(obstaclePrefab, new Vector3(transform.position.x, Random.Range(-2.5f, 2.5f), 0), transform.rotation);
    }
}
