using System;
using UnityEngine;

public class WhackADot : MonoBehaviour
{
    
    void OnMouseDown()
    {
        Debug.Log("WhackADot.OnMouseDown");

        //use the property to change the score
        GameManager.instance.score++;
        
        //make the circle relocate to a random position
    }
}
