using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnScript : MonoBehaviour
{
    public GameObject cloudPrefab;
    private float timer = 0f;
    private float spawnTime = 4f;

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
            spawnCloud();
            timer = 0f;
        }
    }

    void spawnCloud()
    {
        GameObject.Instantiate(cloudPrefab, new Vector3(transform.position.x, Random.Range(-2.5f, 2.5f), 0), transform.rotation);
    }
}
