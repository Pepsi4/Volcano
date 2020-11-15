using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public RoadController RoadController;
    private void OnBecameInvisible()
    {
        //transform.position = RoadController.NextSpawnTransform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -3)
        {
            transform.position = new Vector2(5, transform.position.y);
            RoadController.RoadsPassed++;
        }
    }
}
