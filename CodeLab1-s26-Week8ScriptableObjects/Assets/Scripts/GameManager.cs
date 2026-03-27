using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Central controller that tracks the current location and updates the UI.
public class GameManager : MonoBehaviour
{
    // UI text element that shows the location title.
    public TextMeshProUGUI locationNameDisplay;
    // UI text element that shows the location description.
    public TextMeshProUGUI locationDescriptionDisplay;
    
    // First location shown when the game starts.
    public Location startingLocation;
    // Location the player is currently in.
    public Location currentLocation;

    // Direction buttons that are enabled/disabled based on available exits.
    public GameObject NorthButton;
    public GameObject EastButton;
    public GameObject WestButton;
    public GameObject SouthButton;
    
    // Example reference used during class demos.
    SampleEmptyObject sampleEmptyObject;

    // Simple singleton so other scripts can access the active GameManager.
    public static GameManager instance;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Keep exactly one persistent GameManager across scene loads.
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
        
        // Push the starting location data into all UI elements.
        startingLocation.UpdateLocationDisplay(this);
        
        // Initialize runtime state to match what is shown in the UI.
        currentLocation = startingLocation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void MoveDirection(int direction)
    {
        // Direction mapping:
        // 0 = North, 1 = East, 2 = West, 3 = South.
        switch (direction)
        {
            case 0: //North
                // Keep reverse links synchronized, then move.
                currentLocation.northLocation.southLocation = currentLocation;
                currentLocation = currentLocation.northLocation;
                break;
            case 1: //East
                // Keep reverse links synchronized, then move.
                currentLocation.eastLocation.westLocation = currentLocation;
                currentLocation = currentLocation.eastLocation;
                break;
            case 2: //West
                // Keep reverse links synchronized, then move.
                currentLocation.westLocation.eastLocation = currentLocation;
                currentLocation = currentLocation.westLocation;
                break;
            case 3: //South
                // Keep reverse links synchronized, then move.
                currentLocation.southLocation.northLocation = currentLocation;
                currentLocation = currentLocation.southLocation;
                break;
        }
        
        // Refresh the UI to reflect the new current location.
        currentLocation.UpdateLocationDisplay(this);
    }
}
