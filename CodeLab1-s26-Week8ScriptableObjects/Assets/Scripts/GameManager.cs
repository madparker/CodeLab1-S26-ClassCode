using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI locationNameDisplay;
    public TextMeshProUGUI locationDescriptionDisplay;
    
    public Location startingLocation;
    public Location currentLocation;

    public GameObject NorthButton;
    public GameObject EastButton;
    public GameObject WestButton;
    public GameObject SouthButton;
    
    SampleEmptyObject sampleEmptyObject;

    public static GameManager instance;
    
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

        // startingLocation.name = "Yard"; //Don't do this. Just to show you will overwrite data when you change it in play mode
        
        Debug.Log("Current location: " + startingLocation.name);
        
        // locationNameDisplay.text = startingLocation.name;
        // locationDescriptionDisplay.text = startingLocation.description;
        
        startingLocation.UpdateLocationDisplay(this);
        
        currentLocation = startingLocation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void MoveDirection(int direction)
    {
        switch (direction)
        {
            case 0: //North
                currentLocation.northLocation.southLocation = currentLocation;
                currentLocation = currentLocation.northLocation;
                break;
            case 1: //East
                currentLocation.eastLocation.westLocation = currentLocation;
                currentLocation = currentLocation.eastLocation;
                break;
            case 2: //West
                currentLocation.westLocation.eastLocation = currentLocation;
                currentLocation = currentLocation.westLocation;
                break;
            case 3: //South
                currentLocation.southLocation.northLocation = currentLocation;
                currentLocation = currentLocation.southLocation;
                break;
        }
        
        
        currentLocation.UpdateLocationDisplay(this);
    }
}
