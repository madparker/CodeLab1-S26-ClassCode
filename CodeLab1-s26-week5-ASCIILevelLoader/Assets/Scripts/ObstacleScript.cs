using System;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        ASCIILevelLoader.instance.LoadLevel();
    }
}
