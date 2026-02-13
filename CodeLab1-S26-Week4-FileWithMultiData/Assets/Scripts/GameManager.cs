using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public int score = 0;
    
    //create a basic property for score
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
