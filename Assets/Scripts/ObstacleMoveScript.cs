using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveScript : MonoBehaviour
{
    private float moveSpeed = 3f;
    private float destroyThreshold = -10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x - (moveSpeed * Time.deltaTime), transform.position.y, 0);

        // Destroy Game Object if it has gone behid the camera frame
        if(gameObject.transform.position.x < destroyThreshold)
        {
            Destroy(gameObject);
        }
    }
}
