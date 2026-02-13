using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WhackADot : MonoBehaviour
{
    
    void OnMouseDown()
    {
        Debug.Log("WhackADot.OnMouseDown");

        //use the property to change the score
        GameManager.instance.Score++;
        
        //make the circle relocate to a random position
        Vector2 newPos =
            new Vector2(
                Random.Range(-5f, 5f),  //x
                Random.Range(-4f, 4f)); //y
        
        transform.position = newPos;
    }
}
