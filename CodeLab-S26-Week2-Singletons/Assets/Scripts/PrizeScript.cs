using System;
using UnityEngine;

public class PrizeScript : MonoBehaviour
{
    int relocationRange = 5;
    
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Got hit!");
        
        Vector3 newPosition = new Vector3(
            UnityEngine.Random.Range(-relocationRange, relocationRange),
            UnityEngine.Random.Range(-relocationRange, relocationRange),
            0
        );
        
        transform.position = newPosition;

        GameManager.instance.score++;
    }
}
